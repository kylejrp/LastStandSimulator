# Last Stand - Risk: Global Domination Speedrun Simulator

This is a simulator for the [Final Stand speedrun](https://www.speedrun.com/risk_gd#Final_Stand). In this scenario, the Zombie army has a special condition that when you attack them, you win any ties.

This simulates the probability that the [only recorded one round run has](https://www.youtube.com/watch?v=rJwx86VjKp0).
  
This gives the following output:
```
Running simulations for the following attacks:
Fighting: 19 --> [50, 58]
Fighting: 36 --> [8, 33, 31, 2, 32, (58-?)]
We ran 1,000,000 simulations and won 494 times.
Simulated probability of winning is 0.049%
```

## Building and Running

Make sure you have [.NET Core 5.0 SDK](https://dotnet.microsoft.com/download) installed.

```
dotnet run
```

## Configuring the Simulator

Change the following variables to be whatever you'd like. You can add or remove nodes from `enemyCounts` too.

```
var ourCount = 26;
var enemyCounts = new int[] { 8, 31, 43, 8 };
```
