# Slaiju! Smash the City
![Slaiju Promo Art](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Main%20capsule.png)  

Settle the road for the Kaiju and help it destroy entire cities!  
Help the Kaiju reach the cities by rearranging the tiles. Once a city is reached… LASER!  

Slaiju! Smash the City is the first game jam project (and the last one of the first year!) made at the gaming academy.  
It was a week long project made in Unity by a team of 15 people (7 designers, 2 programmers, 4 concept artists and 2 3D artists).  
For me it was my first game jam and also the first time working with another programmer so I had the opportunity to learn how to organize the work with a colleague of the same department.  

### ***Watch the gameplay [here](https://www.youtube.com/watch?v=Yg__oVLUNyo).***
### ***Download the build [here](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/releases/tag/Slaiju_build).***

<a name="What-I-did"></a>
# What I did
In this game jam project I worked on the kaiju (the character) and on the behaviour of the single cells that populates the map.  

> 1. [Kaiju](#Kaiju)
> 2. [Cells](#Cells)

<a name="Kaiju"></a>
## 1. Kaiju
The kaiju is based on two patterns:
* state pattern: it is based on a finite state machine ([FSM](#FSM)) in order to handle in a flexible way all the different behaviours it has
* the model view controller (MVC) pattern has been integrated to separate the data from the logic and easily handle the visual representation of the kaiju

You can find all the scripts of the character [here](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/tree/main/Assets/Scripts/Character).

<a name="FSM"></a>
### 1.1 FSM
The FSM is based on two scripts you can find [here](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/tree/main/Assets/Scripts/Architecture/State).  
All the character states derive from the [AState script](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Architecture/State/AState.cs).  
The states (and so the rest of the project) use **Unitask** instead of the standard coroutine.  
You can find all the different states of the character [here](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/tree/main/Assets/Scripts/Character/States).  

For the state controller I made the [Character state controller](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Character/CharacterStateController.cs) which derives from the [AStateController](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Architecture/State/AStateController.cs).  
The character state controller contains also the logic to handle the cell in which the kaiju enters, along with the logic to get the entrance side of the cell, as you can see below:
```
        private Vector3 GetCellEntranceSide(BaseCell cell)
        {
            if (Vector3.Dot(transform.forward, cell.transform.right) >= COSINE_TOLERANCE)
                return -cell.transform.right;

            if (Vector3.Dot(transform.forward, -cell.transform.right) >= COSINE_TOLERANCE)
                return cell.transform.right;

            if (Vector3.Dot(transform.forward, cell.transform.forward) >= COSINE_TOLERANCE)
                return -cell.transform.forward;

            return cell.transform.forward;
        }
```

<a name="MVC"></a>
### 1.1 MVC
This pattern has been integrated on the kaiju.  
Separating the data from the logic has made the scripts more readable and organized; in the specific:
* the *model* part of the pattern is the [CharacterData](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Character/CharacterData.cs) script, which is a scriptable object.
* the *view* part of the pattern is the [CharacterView](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Character/CharacterView.cs) script, which handles particles and SFXs of the kaiju.
* the *controller* part of the pattern is the [Character state controller](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Character/CharacterStateController.cs) of the [FSM](#FSM).


**[⬆ Back to Top](#What-I-did)**

<a name="Cells"></a>
## 2. Cells
Each cell in the game is based on the [BaseCell](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Grid/Cell/BaseCell.cs) script.  
Cells can define one or more *safe sides*, which are the directions from which the kaiju can enter the cell without triggering a game over.  
Some cells can be destroyed, the [DestructibleCells](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Grid/Cell/DestructibleCell.cs). Examples of destructible cells include:
* [**City cell**](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Grid/Cell/CityCell.cs)
* [**Generator cell**](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/blob/main/Assets/Scripts/Grid/Cell/GeneratorCell.cs)

**Road cells**, on the other hand, are non-destructible.
Just like the kaiju, cells also have a view. You can find all of them [here](https://github.com/AlessandroSimeoni/Slaiju_SmashTheCity/tree/main/Assets/Scripts/Grid/Cell/Views).

**[⬆ Back to Top](#What-I-did)**
