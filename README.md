# GDIM32 In Class Activities
## Instructions
Put each week's activities under new headers like the one shown above. Headers are created with the # symbol. More # symbols = smaller header.

## week 1
Hit enter TWICE to create a new line.


Activity 1

<<<<<<< HEAD


one piece of advice I received is to frequently go to office hours whenever something is beyond my contol



Activity 2
<<<<<<< HEAD


Q1 : x=10
=======
Q1: x=10



Q2 x= 2


<<<<<<< HEAD
Q3


This code prints "hello world" to the Unity Console every frame.
Q4 

 monobehavior 
=======
Q3: This code prints "hello world" to the Unity Console every frame.


Q4 : monobehavior 



Q5  prints x=10 once when game starts 


Q6. 10 is argument purpose: the value passed to the method 
int x is parameter and receives value inside the method


Q7: its wrong because Transform.Translate() is being called as if it were static.


Q8: _playerTransform.Translate(_direction);

Activity 3


https://docs.google.com/document/d/1WBU7pfuodNjMCsFslRRQIIFg72YVv2mvCpL_aqet-pE/edit?usp=sharing

- Create bullet points by writing d
ashes.
- Here's another bullet point entry.

## week2
![81184493cd6f2bbfa57dec33806ea1b5](https://github.com/user-attachments/assets/c8fd1248-61a5-4b16-b280-5e20b55ea29d)


# link
[

[https://github.com/UCI-GDIM32-W25/mg2-flare-seyn?tab=readme-ov-file](https://github.com/UCI-GDIM32-W25/mg2-flare-seyn/commit/1b76c1c2578a963cfdf526fedcc244540b4ca6ce)
](https://github.com/UCI-GDIM32-W25/mg2-flare-seyn/commit/1b76c1c2578a963cfdf526fedcc244540b4ca6ce)


## Week3


# Activities 0-2
Partner name: Michael Lopez

# Activity 3
<img width="913" height="690" alt="User Research Plan Breakdown" src="https://github.com/user-attachments/assets/37068389-c1de-4e36-8fdf-8bc1e3cc2c20" />


## Week4


# Activity 0
Partner name: Michael Lopez

# answering question
Add multiple Locator objects to the Scene. What happens to the Locator objects when you run the game, and why?

When multiple Locator objects are added to the scene, only one remains when the game runs. This is because the Locator uses the Singleton pattern, which destroys any duplicate instances during Awake(). This ensures that there is only one global access point to the player.

After refactoring, the pigeon no longer directly calls methods on the UI, VFX, or seagulls. Instead, it fires a coo event that other systems subscribe to. This decouples the pigeon from the rest of the game systems and allows new reactions to be added without modifying the pigeon code.

# MG4 break down

<img width="913" height="690" alt="User Research Plan Breakdown" src="https://github.com/user-attachments/assets/7eb08da7-4ca2-4786-b8b7-a4cd4e618831" />

# MG4 first commit and description
https://github.com/flare-seyn/HW4/commit/eb1d40d3a7294e319ebab2157ca2a7a5fda604c0

I've created a new untiy project and forked the HW4 from prof's post.
I downloaded the spirtes and made sprite editor slicing
I added some piece of codes shapesbased on the break down mg4

## Week5

# Activity 1 

I think the overall design choice—using an Item abstract class plus an IBreakable interface—is solid, because it cleanly separates what every item can do (be “used”) from extra behavior only some items have (durability, damage, breaking). In the example, ElvenSword still fits naturally as an Item even though it can’t break, while Torch and Axe opt into IBreakable. That’s a good use of an interface: it avoids forcing every item to carry durability logic just because some items need it.

If I were building a bigger project, I’d keep the same general structure but make a few changes for scalability. First, I’d probably move common durability logic into a shared base class like BreakableItem : Item, IBreakable, so Axe and Torch don’t duplicate the same “subtract durability → log → check break” code. Second, I might rename Damage(float damage) to something like TakeDamage(float amount) for clarity, and consider whether “damage” should always mean durability loss (since items aren’t living entities). Overall, though, the separation of responsibilities here feels clean and I’d keep that pattern.

# Activity 2

for week5 demo2 the MVC pattern is implemented by separating game data, visual display, and control logic across different classes. The Model is represented by the ScriptableObject classes ItemW5Demo2 and EnemyStats, which store item data, enemy stats, and dialogue lines. The player’s inventory list (List<ItemW5Demo2>) also functions as part of the Model, since it represents the current game state rather than UI or input behavior.

The View is handled by classes whose sole responsibility is displaying information to the player. InventoryUI manages showing and hiding the inventory panel and rendering the item list text, while DialogueBubble displays enemy dialogue and controls its visibility. These classes do not contain gameplay logic or input handling.

The Controller logic lives primarily in PlayerW5Demo2 and EnemyW5Demo2. PlayerW5Demo2 processes player input for movement and inventory toggling, updates the player’s position, and passes Model data to the inventory UI. EnemyW5Demo2 checks the player’s distance, reads dialogue data from EnemyStats, and tells the dialogue View when to show or hide. Together, these controller scripts connect the Model and View, completing the MVC structure used in the scene.


# Activity 3

 
 # Scenario 1

      For Nemo’s rhythm game, I think the best architecture is ScriptableObjects + inheritance/interfaces + MVC/events. Each “beat type” should be represented as data (what key, when it    appears, where it spawns, what it looks like, scoring windows), so I’d make a BeatData : ScriptableObject that contains fields like KeyCode requiredKey, float timeStamp, Vector2 lanePosition, maybe BeatKind (tap/hold/slide), plus references to VFX/audio cues. Then, the actual on-screen beat object would be a View MonoBehaviour like BeatView, which reads a BeatData and moves itself based on song time. For code structure, I’d use a basic parent class/abstract class like Beat or BeatBehavior with polymorphism, and then child classes like TapBeat, HoldBeat, SlideBeat for the unique behavior (e.g., hold duration checking). If I want shared “hittable” logic, an interface like IHittable could help. For the overall flow, MVC with C# events makes sense: a SongController (Controller) updates timing, a BeatManager spawns beats, and events like OnBeatHit, OnBeatMiss update the score UI (View) without hard coupling.
      
 # Scenario 2

     For Leo’s shooter, I think the best patterns are inheritance with polymorphism + FSM + MVC/events, with ScriptableObjects to store character/weapon/ability data. The characters share core systems (health, movement, animation rig setup), so I’d make a base parent class like CharacterBase that contains shared components and hooks (movement controller, health, animator references). Then I’d use polymorphism for the unique attacks/abilities by defining an abstract ability system: either an abstract Ability class with Activate() / Cooldown() methods, or interfaces like IAbility, IAttack, IUltimate. Each character would be composed of multiple abilities rather than putting all logic directly into the character class. For the fact that characters have multiple movement/attack modes, a Finite State Machine with enums is a great fit (states like Idle, Run, Jump, Aim, Reload, CastingAbility, etc.), and the FSM would drive animation transitions cleanly. MVC with C# events is useful so the gameplay code (Model/Controller) can trigger UI updates (health bars, cooldown UI, crosshair) without directly editing UI objects. A Singleton can be appropriate for global managers like GameManager, AudioManager, or MatchStateManager, but I’d keep it limited so it doesn’t turn into “everything is global.”

 # Scenario 3

     For Willow’s farming sim, the best patterns are ScriptableObjects + interfaces/abstract classes + FSM + MVC/events. There are many “things” on the farm (rocks, crops, seeds, harvestables) that share some common concepts but behave differently. I’d represent item and crop types as ScriptableObjects: SeedData, CropData, ResourceNodeData (rock/tree), containing sprites, growth time, drop tables, etc. Then, in the world, I’d have MonoBehaviours like CropPlot, CropInstance, ResourceNode that reference those ScriptableObjects. To handle different interactions, I’d use interfaces like IPlantable, IHarvestable, IDamageable, IToolInteractable. That way, tools can interact with anything that supports the interface (e.g., hoe plants, axe damages trees, pickaxe damages rocks). For the player’s animations and actions, a Finite State Machine is perfect: states like Idle, Walk, Hoe, Plant, Water, Harvest, Chop, Mine, etc. The FSM would control animation and prevent conflicting actions (you can’t harvest and water at the same time). MVC with events helps keep UI clean: the inventory/hotbar UI (View) updates based on inventory changes (Model) via events like OnInventoryChanged, OnSelectedToolChanged. Again, a small Singleton (like InventoryManager or DayNightManager) can work if used carefully.

# Activity 4

Attendence: Nansong Sun, Rebecca Feng , Frances Nareh Kim
Link:  https://docs.google.com/document/d/12oXcMbRqu-4vIfI7XU0rpLQhKyyF9Gy7RNBljYCJIrA/edit?tab=t.0#heading=h.y4j3q551ojs1

## Week 6

# Activity 1 
 for demo1: 
  In Demo1_Gizmos, I reviewed custom Gizmo scripts including CircleColliderGizmo and VelocityGizmo. The CircleColliderGizmo script uses a serialized CircleCollider2D reference and OnDrawGizmos to draw a wire sphere at the collider’s offset/radius. VelocityGizmo similarly uses OnDrawGizmos with a Rigidbody2D reference to draw a direction ray from current velocity. This is useful for us because we have many interactables and detection ranges; drawing pickup radius, talk radius, and movement vectors in Scene view would make tuning interactions faster and reduce guesswork. For our final project, I want Gizmos for NPC talk range, item collection radius, oven interaction zone, and quest objective areas.
  for demo2:
  In Demo2_Profiling, I looked at GameController code that spawns many fruit objects (_numFruit = 100) and stores them in a List<GameObject> _fruits. The script also includes a commented foreach debug loop in Update, which is a good reminder that repeated Debug.Log calls in loops can hurt performance. The scene reinforced profiling mindset: avoid expensive per-frame work unless needed, cache references, and move one-time setup into Start/Awake. For our game, this matters because inventory/UI/quest checks could become heavy if we run full validation every frame. I should use event-driven updates (only refresh UI when inventory/quest data changes) instead of constantly polling.
  for demo3:
  In Demo3_Breakpoints, I reviewed CapybaraW6Demo3 and GameControllerW6Demo3. CapybaraW6Demo3 includes a singleton pattern (public static Instance with duplicate guard in Start), movement input logic in Update, and a ResetLocation method. GameControllerW6Demo3 includes reset flow that destroys old fruit, clears/rebuilds the fruit list, respawns objects in world bounds, and resets player location. This was useful for understanding where to place breakpoints and inspect state transitions step-by-step (especially reset logic and list mutation). For our project, breakpoints will be important when debugging quest progression, recipe validation order, friendship unlock conditions, and fail/win state transitions.
  Concrete ways I’ll apply this to our final project:
    Add OnDrawGizmos for interaction radii (collectables, NPCs, oven).
   Add Gizmos for spawn bounds and objective hotspots.
   Keep heavy logic out of Update; use events for inventory/quest/UI sync.
   Use breakpoints in quest controller, dialogue branch resolver, and recipe checker.
   Use a controlled reset method (clear spawned objects + reset player + reset state) for testing loops.
   Use singleton only for true global managers (carefully, to avoid over-coupling).

# Activity 2
Attendence: Nansong Sun Landon Peev Xwm Her( others are attending GDW talks that they informed us already)
final proposal link: https://docs.google.com/document/d/12oXcMbRqu-4vIfI7XU0rpLQhKyyF9Gy7RNBljYCJIrA/edit?usp=sharing



## Week7
# Activity1
notes: in the week7 demoscene, theres a player object , multiple typical green trees object, a duck object and a special pink tree object.
player use wasd to move and when the the player is too near and facing the duck object without obstacles, the duck will transform to a 
red form (raged?) and start to chase the player object unless they lose direct sight( player hiding behind a tree). unlike other green trees,
the special pink tree cant serve as a sight obstacle and the duck will rage as long as it sees the player object around that pink tree.

# Activity 2
attendance: Rebecca Feng Frances Nareh Kim Landon Peev Xwm Her Nansong Sun

# Activity 3
breakdown
![IMG_3601](https://github.com/user-attachments/assets/72e69b74-1e7b-4833-b5e6-6313871ca3c2)

# Activity 4
spreadsheetlink:
https://docs.google.com/spreadsheets/d/1Zv6t-jtaA3FyTzVV6nuGgsbLFK90LGVoSos6l5H0YpU/edit?gid=0#gid=0

# Activity 5
https://github.com/fnkim/GDIM32-Final/commit/8a20e64254e3790f7b4631f53c643ee290bdd3b7
I added 3 variant of prefabs to satisfy the different collectable resources from them ( blueberry, strawberry, lemon)and added a collider so player can interact and destroy them once steeping on

