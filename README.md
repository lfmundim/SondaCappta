# Sonda - Cappta
Repo created as an attempt at [this test](https://gist.github.com/rmterra/31f2b4f589250839550f685d8873d935).

The following instructions were not explicit, therefore I took the liberty of defining them:
1. **Probe Collision:** it was not clear if probes could occupy the same coordinates as each other. Decision: there **is** probe collision and they **cannot** occupy the same coordinates. On a given collision, the probe will stay in place.
```csharp
// snippet
    private bool IsProbeBlockingTheWay(Coords coord) => Probes.Any(p => p.Coords.Equals(coord));
```
2. **Input:** as it was not defined which input to use, only the format, I implemented the two most common ways seen on Online Judges: **console input** and **files**. There is still a need for manual console input to choose wich way.
```csharp
// snippet
    var readType = Console.ReadLine();
    if (readType.Equals("1"))
    {
        fileInputFacade.ReadInput();
    }
    else if (readType.Equals("2"))
    {
        inlineInputFacade.ReadInput();
    }
```
3. **Output:** as it was not defined where to output, I chose the most common and basic one: the console. Whenever a probe command input is over, its output is printed. This could easily be changed to print only when all inputs are done, as the `Field` object contains all probes' info. A snippet for that would be:
```csharp
// snippet
    foreach(probe in _field.Probes)
    {
        Console.WriteLine(probe.GetPosition())
    }
```

The basic test case from the Gist can be found on the unit tests project, both using file and inline.
