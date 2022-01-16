using Seventeen;

var target = new Area(new(156, 202), new(-110, -69));
var collator = new ValidTrajectoryCollator(target);

Console.WriteLine(collator.CountValidTrajectories());
