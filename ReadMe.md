# Military system
[For some sweet screen shots check out this link](http://best.telerikacademy.com/projects/260/MVC)
## Database
### Users
1. Admin - Can manage all objects(Add, Delete, Change)
2. User - Can send orders to different groups depending on rank.
Has a collection of objects (weapons + gear)
### Vehicles
#### 3 sub divisions

1. Air
2. Ground
3. Water

### Message 
### Weapons

### Gear

### Squad - Holds n amount of soldiers

### Platoon - Holds n amount of squads

### Mission - Holds details about a mission

## Models details
### User(soldier)(admins are also soldiers*)
+ Rank(int based)
+ First/Last name
+ Collection of Weapons
+ Collection of Gear
+ Enrollment date
+ Collection of Missions
+ Wage(decimal)

### Vehicles - Will be the last model in if I have time

### Mission
+ Info content
+ Location (GPS coordinates)
+ Type(enum) - Attack/Defend/Resupply/Search&Rescue
+ Succeeded - true/false
+ Squad - the squad that is assigned to the mission

### Message
+ User - from user
+ Content

### Squad
+ 1 user as squad leader
+ Collection of soldiers
+ Squad name
+ Current GPS coordinates
+ Collection of vehicles
+ Collection of messages from soldiers
+ Collection of missions

### Platoon
+ 1 user as platoon leader
+ Platoon name
+ Collection of squads
+ Collection of messages from squad leaders

### Administration(Probably just use UserRoles mehh..)
+ Collection of admin users
+ Collection of Messages from platoon leaders
+ Bools that grant/deny access 
 + CanManageSoldiers
 + CanManageMessages
 + CanManageGear - weapons/gear
 + CanManageVehicles
The above provide a more flexible administration - different divisions of administrators

## Web application general idea
+ Platoon leaders
 +  Can send orders(Mission object) to a given squad (Attack/Defend/Resupply/Search & Rescue etc.)
 +  Platoon leaders will have a shared chat*.

+ Squad leaders
 +  Can give orders to individual soldiers.
 +  Can send proposals/requests to platoon leaders.
 +  Squad leaders will have a shared chat + PM to soldiers.

+ Administration
 + Can add new Soldiers, Weapons, Vehicles, Gear.
 + Can create new squads/platoons and manage them.
 + Can receive messages from platoon leaders.
 + Can promote soldiers.
. 

# TODO
##Troops
1. Init chat with channel switcher "Alpha , Bravo etc
2. Style messanger and link to push notifications
3. Create add mission template for commander
4. Mark mission as successfull ability for commander
5. Add escaping role access validation 
6. Extract actions in controllers
7. Savable View*@@@@

## ADMIN
1. List all Models with kendo grid Page Filter etc,
2. Add/MOD templates FOR all + view Models with validation
3. Stats pages with charts FOR all ( individual with cache )
