using ContainerManager;

var vessel1 = new Vessel(100, 1000, 10000);
var vessel2 = new Vessel(70, 725, 3000);

var waterContainer = new LContainer(25, 5, 10, 100, false);
var gasolineContainer = new LContainer(30, 10, 10, 200, true);
var propaneContainer = new GContainer(9.5f, 3, 3, 50, true);
var meatContainer = new CContainer(13.2f, 9, 5, 100, "Meat");
var chocolateContainer = new CContainer(9.35f, 3.5f, 4.5f, 75, "Chocolate");

Console.WriteLine($"{waterContainer}\n{gasolineContainer}\n{propaneContainer}\n{meatContainer}\n{chocolateContainer}");

waterContainer.Load(35);
waterContainer.Unload();
waterContainer.Load(135);
waterContainer.Load(55);

gasolineContainer.Load(155);
gasolineContainer.Load(45);

propaneContainer.Load(50);
propaneContainer.Unload();
propaneContainer.Load(25);

meatContainer.Load(25);
meatContainer.Unload();
meatContainer.Load(99.5f);

chocolateContainer.Load(55.76f);

vessel1.LoadContainer(waterContainer);
vessel1.UnloadContainer(waterContainer);
vessel1.LoadContainer(gasolineContainer);
vessel1.ReplaceContainer("KON-L-2", propaneContainer);
vessel1.TransferContainer(propaneContainer, vessel2);
vessel1.LoadContainers([waterContainer, meatContainer, chocolateContainer]);

Console.WriteLine($"{vessel1}\n{vessel2}");
