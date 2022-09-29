
public static class Helper
{
    public static Task<TResult> WhenAll<TResult>(params Task<TResult>[] task)
    {
        TaskCompletionSource<TResult> res = new TaskCompletionSource<TResult>();

        Task.Factory.ContinueWhenAny(new Task<TResult>[] { task[2], task[0], task[1] },
         t => {
             foreach (var item in task)
             {
                 try
                 {
                     if (item.IsFaulted)
                     {
                         res.SetException(item.Exception);
                     }
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);
                 }
                 res.SetResult(item.Result);
             }
            
         });

        return res.Task;
    }
   

    }
    
