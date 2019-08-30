using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace File_System_Browser_Library
{
    public delegate bool FSItemProcessor(string fsItem);
    public delegate bool FSExceptionHandler(Exception ex);
    public delegate void ProcessCompleteEventHandler(object sender, EventArgs e);

    public class FSBrowser
    {
        private Thread browserThread;
        private FSItemProcessor fsItemProcessor;
        private FSExceptionHandler fsExceptionHandler;        
        private string startPath;
        private bool stopRequest;
        private int maxDepth;

        public event ProcessCompleteEventHandler ProcessCompleted;

        public FSBrowser(string path, int maxDepth, FSItemProcessor itemProcessor, FSExceptionHandler exHandler)
        {
            Initialize(path, maxDepth, itemProcessor, exHandler);
            browserThread = new Thread(new ParameterizedThreadStart(_ThreadMethod));
        }

        public void Initialize(string path, int maxDepth, FSItemProcessor itemProcessor, FSExceptionHandler exHandler)
        {
            if (path == "" || path == null)
                throw (new ArgumentNullException("The path argument must contain a valid path."));
            if (itemProcessor == null)
                throw (new ArgumentNullException("The itemProcessor argument must contain a valid method delegate."));

            startPath = path;
            this.maxDepth = maxDepth;
            fsItemProcessor = itemProcessor;
            fsExceptionHandler = exHandler;
            stopRequest = false;
        }

        public FSBrowser()
        {
            browserThread = new Thread(new ParameterizedThreadStart(_ThreadMethod));
        }

        /// <summary>
        /// Starts the file system browser thread.
        /// </summary>
        public void Start()
        {
            if (startPath == null)
                throw (new InvalidOperationException("Initialize() must be called before calling Start()"));

            if (browserThread.IsAlive)
                throw (new InvalidOperationException("The thread is already active."));

            if (browserThread.ThreadState != ThreadState.Unstarted)
                throw (new InvalidOperationException("The thread is not in unstarted state. Call Reset() first to re-initialize it."));

            browserThread.Start(new ThreadMethodArgs(startPath, 0));
        }

        /// <summary>
        /// Kills the file system browser thread.
        /// </summary>
        public void Halt(bool waitTillStopped)
        {
            if (!browserThread.IsAlive)
                throw (new InvalidOperationException("The thread is already stopped."));

            stopRequest = true;
            if (waitTillStopped)
                browserThread.Join();
            return;
        }

        /// <summary>
        /// Get the state of the thread that is executing the browsing code. Use this method to determine if the thread
        /// has stopped or not after calling Halt();
        /// </summary>
        /// <returns>True if the thread is running or false otherwise.</returns>
        public ThreadState GetInternalThreadState()
        {
            return browserThread.ThreadState;
        }

        public void Reset()
        {
            if (browserThread.ThreadState != ThreadState.Aborted && browserThread.ThreadState != ThreadState.Stopped)
                throw (new InvalidOperationException("The thread has not yet stopped."));

            stopRequest = false;
            browserThread = new Thread(new ParameterizedThreadStart(_ThreadMethod));
        }

        private void _ThreadMethod(object args)
        {
            string[] dirNames = { "" };
            string[] fileNames = { "" };

            try
            {
                dirNames = Directory.GetDirectories(((ThreadMethodArgs)args).path);
                fileNames = Directory.GetFiles(((ThreadMethodArgs)args).path);
            }
            catch (Exception ex)
            {
                ex.Data.Add("Path", ((ThreadMethodArgs)args).path);
                if (fsExceptionHandler != null)
                    if (fsExceptionHandler(ex))
                        return;
                throw;
            }

            for (int i = 0; i < dirNames.Length; i++)
            {
                if (stopRequest)
                    return;
                if (!fsItemProcessor(dirNames[i]))
                    dirNames[i] = String.Empty;
            }

            foreach (string name in fileNames)
            {
                if (stopRequest)
                    return;
                fsItemProcessor(name);
            }
            fsItemProcessor("\\");


            if (maxDepth == -1 || ((ThreadMethodArgs)args).depth != maxDepth)
            {
                foreach (string name in dirNames)
                {
                    if (stopRequest) 
                        return;
                    if (name != String.Empty)
                        _ThreadMethod(new ThreadMethodArgs(name, ((ThreadMethodArgs)args).depth + 1));
                }
            }

            if (String.Compare(startPath, ((ThreadMethodArgs)args).path, true) == 0 && !stopRequest)
                ProcessCompleted(this, EventArgs.Empty);
        }
    }

    class ThreadMethodArgs
    {
        public string path;
        public int depth;

        public ThreadMethodArgs(string path, int depth)
        {
            this.path = path;
            this.depth = depth;
        }
    }
}