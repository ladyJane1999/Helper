
class Program
{
    static async Task Main(string[] args)
    {

        var tasks = new List<Task<string>>();
        for (var i = 1; i < 4; i++)
        {
            var iteration = i;
            Task<string> task = Task.Run<string>(async () =>
            {
              if(iteration == 2)
                {
                    throw new Exception("Exception");
                }
                await Task.Delay(100);
                Console.WriteLine($"Iteration {iteration}");
                return "iteration";
            });

            tasks.Add(task);
        }
        try
        {
            await Helper.WhenAll(tasks[0], tasks[1], tasks[2]);
        }catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());   
        }
      
    }
}
