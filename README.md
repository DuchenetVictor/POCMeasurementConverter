# POCMeasurementConverter

My main direction was to make a POC witch is easy to implement new measurement with a single class doing all the work `ConverterBase.cs`. 


In every new measurement you just need to make a new subClass of ConverterBase and implement the only one abstract 
method `List<Unit> GetUnits()` in order to make a new measurement.

For this type of single task application, I focus a lot in a very light and useful design. The application focus on only one task, so the user need to do it quickly with the less action possible.

The app listen to your window theme (dark or light) and also uses your accentuation color . 

The UI and the code isn't perfect, but I assume that I don't need to spend too much time on it (first because it's a POC and not a final product, seconde because the consigne said hour or couple hours).


## TODO
* Add unit test
* Finish the disabled button on menu ( juste add the new measurement Imperial volume etc...)
* Add converter between metric system and imperial system
* maybe add devise converter (lots of work..., network depedant ...)
* Use a DB to track the historic

