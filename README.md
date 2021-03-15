# Last Stand - Risk: Global Domination Speedrun Simulator

This is a simulator for the [Final Stand speedrun](https://www.speedrun.com/risk_gd#Final_Stand). In this scenario, the Zombie army has a special condition that when you attack them, you win any ties.

To beat this scenario in one round, your dice rolls have to be extremely good. I wanted to get a rough estimate of how good the rolls had to be, so I wrote this simulator to calculate the probability of the following scenario:
- You are attacking from Eastern Ramparts with 26 troops
- You need to attack on each of these territories successively:
  - 8 Zombies on Siege Tower
  - 31 Zombies on North Bank
  - 43 Zombies on Siege Encampment
  - 58 Zombies on Siege Headquarters
  
This gives the following output:
```
Running simulations for the following attack:
Fighting: 26 --> [8, 31, 43, 58]
We ran 1,000,000 simulations and won 332 times.
Simulated probability of winning is 0.033%
```

<img src="https://user-images.githubusercontent.com/6742479/111099902-b996dc80-8503-11eb-9399-7267c86a9e5b.png" width="307" height="453">

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
