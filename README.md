# Against the Slime Storm

A grid-based tower defence made for **Brackeys Game Jam 2024.2** in Unity. A peaceful kingdom
of potatoes, a lightning strike on an old ritual circle, and a tornado full of slime.

**Play in the browser:** https://voky00.itch.io/against-the-slime-storm
**Portfolio write-up:** https://tomas-vokoun.dev

---

## The design problem

Three tower roles, two passive income curves and a wave count that keeps climbing. That is the
whole game, and it is entirely a tuning problem: if wood accumulates slightly too fast the
magic tower stops being a decision, and if the basic tower is a little too cheap nothing else
gets built. **Balancing the tower prices and the mine upgrades was my main job on this project.**

## Systems

**Two resources, both passive.** Gold and wood accumulate on their own. The player does not
gather them by hand — they invest in **mines**, and upgrading a mine raises the rate. So every
coin spent is a choice between defending the current wave and compounding for later ones.

**Three tower types, all upgradeable.**

| Tower | Fire rate | Damage | Role |
|---|---|---|---|
| Basic | medium | medium | the default answer, cheap enough to spam early |
| Submachine gun | fast | low | volume against many weak slimes |
| Magic | slow | high | single big targets |

Each has its own upgrade path, so a player can go wide or tall.

**Waves that keep growing.** Enemy waves never stop escalating, which is what forces the income
investment to matter. Survive longer than anyone else.

## Code layout

Gameplay code is under `Against the slime storm/Assets/Scripts/`:

```
entities/
  Tower.cs          a tower: type, fire rate, damage, upgrade level
  Bullet.cs         projectiles and hit resolution
  Slime.cs          the enemies
  GatheringHous.cs  the mines — passive gold/wood income and their upgrades
  Tile.cs           one grid cell: buildable or not, what occupies it

global/
  GameManager.cs    the run: resources, state, win/lose
  Wave.cs           wave composition and escalation
  Bar.cs            health/progress bars
  MenuManager.cs    menus

menus/
  TowerBuild.cs     placement and purchase
  Tooltip.cs, TooltipManager.cs   what a tower costs and does, before you buy it
  FadingText.cs     floating feedback
```

`Tower.cs` and `GatheringHous.cs` are the two files the balance actually lives in — tower cost
and damage on one side, income rate and upgrade cost on the other. `Wave.cs` is the pressure
they are balanced against.

## Running it

Unity project — open `Against the slime storm/` in Unity Hub. The published build is WebGL.

## Note on the repository

Made under jam time pressure and pushed as-is, so Unity's generated folders are committed
alongside the source. Everything written by hand is in `Assets/Scripts/`. `GatheringHous.cs` is
a typo I never went back to fix.

## Credits

- Art — [AnnusTheChosenOne](https://annusthechosenone.itch.io)
- Everything else (code, systems, balancing) — me
