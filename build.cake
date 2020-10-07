var defaultTask = Task("Default");

for(int index = 1;index <= 5; index++)
{
    defaultTask.IsDependentOn(
        Task($"Task {index}")
            .Does(()=>Information("Task {0}", index)
        )
    );
}

TaskSetup(context=>{
    System.Console.WriteLine($"::group::{context.Task.Name}");
});

TaskTeardown(context=>System.Console.WriteLine("::endgroup::"));

RunTarget("Default");