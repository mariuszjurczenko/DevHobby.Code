using DevHobby.Code.Lego;

Dog myDog = new Dog();
myDog.Name = "Burek";
myDog.Breed = "Doberman";
myDog.Age = 5;

Dog neighborsDog = new Dog();
neighborsDog.Name = "Azor";
neighborsDog.Breed = "Bernardyn";
neighborsDog.Age = 3;

myDog.IntroduceYourself();
myDog.Bark();

neighborsDog.IntroduceYourself();
neighborsDog.Bark();