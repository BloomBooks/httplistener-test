Windows updates KB 5066835 (and maybe 506589?) breaks [our app](https://bloomlibrary.org/page/resources/downloads) (all versions) on significant portion of machines. This repro is a minimal reproduction.

```

ERROR: 50 - The request is not supported.
Unhandled exception. System.Net.Http.HttpRequestException: An error occurred while sending the request.
 ---> System.IO.IOException: Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host..
 ---> System.Net.Sockets.SocketException (10054): An existing connection was forcibly closed by the remote host.
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.CreateException(SocketError error, Boolean forAsyncThrow)
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ReceiveAsync(Socket socket, CancellationToken cancellationToken)
   at System.Net.Sockets.Socket.ReceiveAsync(Memory`1 buffer, SocketFlags socketFlags, Boolean fromNetworkStream, CancellationToken cancellationToken)
   at System.Net.Sockets.NetworkStream.ReadAsync(Memory`1 buffer, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnection.InitialFillAsync(Boolean async)
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](TStateMachine& stateMachine)
   at System.Net.Http.HttpConnection.InitialFillAsync(Boolean async)
   at System.Net.Http.HttpConnection.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Runtime.CompilerServices.AsyncMethodBuilderCore.Start[TStateMachine](TStateMachine& stateMachine)
   at System.Net.Http.HttpConnection.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext()
   at System.Threading.Tasks.AwaitTaskContinuation.RunOrScheduleAction(IAsyncStateMachineBox box, Boolean allowInlining)
   at System.Threading.Tasks.Task.RunContinuations(Object continuationObject)
   at System.Threading.Tasks.Task`1.TrySetResult(TResult result)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.SetExistingTaskResult(Task`1 task, TResult result)
   at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecutionContextCallback(Object s)
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.MoveNext(Thread threadPoolThread)
   at System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1.AsyncStateMachineBox`1.ExecuteFromThreadPool(Thread threadPoolThread)
   at System.Threading.ThreadPoolWorkQueue.Dispatch()
   at System.Threading.PortableThreadPool.WorkerThread.WorkerThreadStart()
--- End of stack trace from previous location ---

   --- End of inner exception stack trace ---
   at System.Net.Http.HttpConnection.InitialFillAsync(Boolean async)
   at System.Net.Http.HttpConnection.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   --- End of inner exception stack trace ---
   at System.Net.Http.HttpConnection.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.<SendAsync>g__Core|83_0(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationTokenSource cts, Boolean disposeCts, CancellationTokenSource pendingRequestsCts, CancellationToken originalCancellationToken)
   at MinimalRepro.Main() in D:\httplistener-test\minimal-repro\Program.cs:line 34
   at MinimalRepro.<Main>()
```
