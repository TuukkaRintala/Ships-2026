# Designing navigation areas for ship pathfinding

## Different navigation area types and their costs
- Calm seas = 10
- Non-navigable (islands) = -1
- Stormy seas = 20
- Current = 15
- Rocky areas = 50
- Swamps = 40
- Vortex edge = 15
- Vortex halfway = 50
- Vortex centre = 100
- Shallows (non-navigable for big ships) = 10/-1

## A method for detecting area types
Make each Cell object contain a Area3D collision plane, the size of which is determined by cell size. Make the different visual objects that indicate navigation area types (Rocks, islands etc.) have their own Area3D collision planes and assign them their navigation costs.
When populating the grid have each colliding navigation area type pass on their navigation cost and have the highest (or -1 if non-navigable) become the priority of that cell.

### Godot Node types:
- Node3D (we want the Cells and othe objects to have a 3D position)
- Area3D/StaticBody3D (we use this to detect collisions)
- CollisionShape3D (we use this to detect collisions)
- MeshInstance3D (for adding visual indicators)

## Pseudocode
METHOD WHEN_COLLISION_HAPPENS(OBJECT)
{
    IF (OBJECT is a NAVIGATION AREA)
    {
        IF (OBJECTS_NAVIGATION_COST is greater than CELLS_NAVIGATION_COST or
            OBJECTS_NAVIGATION COST is equal to NON_NAVIGABLE)
        {
            CELLS_NAVIGATION_COST = OBJECTS_NAVIGATION_COST
        }
    }

}
