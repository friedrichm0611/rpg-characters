# rpg-characters
rpg Character - Noroff assignment

# General
The program is part of Noroff's assignment to create character classes to understand and practise Object Oriented Programming.
I'm coming from PHP and I used OOP style there as well, but not at this detailed structure. PHP was equipped with OOP very late, I think in version 5.
I generally understand the principals of OOP but have to learn much more about that. More practice will help to apply the learned stuff.

# Usage
Just run the program in Visual Studio and have a look at the Main() method. You can create one of the characters (see examples) and equip it with weapons and armor as you like.
There're already some data to play with. I left also some "Console.Writeline()" methods that you have a better overview what happens.
Feel free to create weapon and armour object with different values.

Following methods are available for the characters:

showBaseStats() - shows the base stats
LevelUp() - levels the character up. The character gains 1 level with every call of this method. Every character class has different attribute values for levelling.
EquipWeapon( WeaponObj ) - This method requires a weapon object. This object has to look always the same (requirement), in example:

Weapon testStaff = new Weapon()
    {
    ItemName = "Common Staff", // String
    RequiredLevel = 1, // int
    ItemSlot = Slot.SLOT_WEAPON, // Enum Slot
    TypeOfWeapon = WeaponType.WEAPON_STAFF, // Enum WeaponType
    Damage = 7, // int
    AttackSpeed = 1.7 // double
    };

ItemName - A string with the name of the weapon.
RequiredLevel - Your character has to be at this level to use this weapon. If not, an individual error exception is thrown and the program stops/exits.
ItemSlot - This is the slot in which the weapon is stored (in fact the weapon is not stored but the calculated values/attributes from it). For weapons the Slot must always be SLOT_WEAPON.
TypeOfWeapon - As the name tells us, the type of the weapon. Every character has weapon restrictions. If the character is not allowed to use it an individual error exception is thrown and the program stops/exits.
Damage and AttackSpeed - That are values to calculate the damage per second. See # Attribute calculation.

EquipArmour( ArmourObj ) - This method requires an armour object. This object has to look always exactly the same (requirement), in example:

Armour testClothHead = new Armour()
    {
    ItemName = "Common cloth head armour", // String
    RequiredLevel= 1, // int
    ItemSlot= Slot.SLOT_HEAD, // Enum Slot
    ArmourType = ArmourType.ARMOUR_CLOTH, // Enum ArmourType
    Strength = 1, // int
    Intelligence = 0, // int
    Dexterity = 0, // int
    };

ItemName - A string with the name of the armour.
RequiredLevel - Your character has to be at this level to use this armour. If not, an individual error exception is thrown and the program stops/exits.
ItemSlot - This is the slot in which the armour is stored (in fact the armour is not stored but the calculated values/attributes from it). It can be SLOT_HEAD, SLOT_BODY and SLOT_LEGS (Enum).
ArmourType - Type of armour. Every character has armour restrictions. If the character is not allowed to use it, an individual error exception is thrown and the program stops/exits.
Strenth, Intelligence and Dexterity - ..are values to calculate the total attributes. See # Attribute calculation

If an armour is set to a slot that is already used, the new amour overrides the current. The calculated attribute values are held in a dictionary.
This way allows to calculate all the weapon and armour attributes from the beginning.

# Attribute calculation

It could last hours to describe that with words. I used the following overview as a comment in my app (it's still in there..).
Please note that this is/was my understanding of it. It may vary from the guideline, but I tried.
(I know it's not an easy discussion. I think the developers of Diablo 3 or the like have discussed night after night how to implement).

S, D and I stand for Strenth, Dexterity and Intelligence


*** Base Attributes ***
Mage: S = 1, D = 1, I = 8 Initial
lvlup: S += 1, D +=1, I +=5 , Level +=1
Level2: S = 2, D = 2, I = 13
Base Damage (Intelligence) = I + (I *100 / 1)  ( 8 -> 8,08)

*** 3 x Armor Attributes ***
Head, Body, Legs => Strength = Total Attribute = BaseStrength + Head + Body + Legs

*** Weapon Damage ***
DPS = Damage (Weapon) * Attack Speed

*** Character Damage ***
Total Attribute = DPS * (1 + Total Attribute / 100)

*** Total attribute calculation ***
Total Base Damage: S + D + (I + (I * 100 / 1)) // Mage
If Head is equipped -> + 1 * Base Attributes
If Body is equipped -> + 1 * Base Attributes
If Legs is equipped -> + 1 * Base Attributes

All Equipped Armor: Head + Body + Legs

# Known issues
 - Missing error handling when a weapon or amour object is not created as described above. 
 - Unfortunately I realized too late that I change the base values by levelling up. That could be (quite easyly) solved by separating base values and level values. I haven't changed because time is running away.
 - The above mentioned methods could be outsourced to a separate class to inherit. Maybe the dictionaries as well.
 - I tested all the characters with different weapons and armours but had no time left to implement unit testing. A pity because I worked 3 years in quality management. Could have been interesting.