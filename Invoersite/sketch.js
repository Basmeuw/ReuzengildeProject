let n = 0;
var nOfDeelnemers = 15;

var hasInitialized = false;

//vars
var displayName = [];
var name = [];
var description = [];
var bestandnaam = [];

//elements
var e_deelnemerDiv = [];
var e_collapseButtonSpan = [];
var e_collapseButton = [];
var e_deelnemerName = [];
var e_inputDiv = [];
var e_nameLabel = [];
var e_nameInput = [];
var e_descLabel = [];
var e_descInput = [];
var e_bestandLabel = [];
var e_bestandInput = [];
var e_saveButton = [];

var collapsebutton = [];

//firebase
var database;
var retrievedData = [];


function setup() {

  //Setup voor verbinding met firebase
  var config = {
    apiKey: "AIzaSyCHGwKRUx1IJ7b-42rhqOEu2vLhQjJMbaY",
    authDomain: "test-project-be3a3.firebaseapp.com",
    databaseURL: "https://test-project-be3a3.firebaseio.com",
    projectId: "test-project-be3a3",
    storageBucket: "test-project-be3a3.appspot.com",
    messagingSenderId: "933378213289"
  };

  firebase.initializeApp(config);
  database = firebase.database();

  //Wanneer de site voor het eerst wordt opgestart wordt alle informatie uit de db gehaald, en de HTML geinitialized
  database.ref('deelnemers').once('value', function(snapshot){
    retrievedData = snapshotToArray(snapshot);
    if(!hasInitialized){
        initializeHTML();
    }
  });
}

//functie die een array uit de database haalt met alle informatie over de deelnemers erin
function snapshotToArray(snapshot) {
    var returnArr = [];

    snapshot.forEach(function(childSnapshot) {
        var item = childSnapshot.val();
        item.key = childSnapshot.key;

        returnArr.push(item);
    });
    return returnArr;
};

//deze functie slaat alle data die nu in de tekstvakken staat op
function saveData(){
	for(n = 0; n < nOfDeelnemers; n++){
		var name = e_nameInput[n].value();
		var desc = e_descInput[n].value();
    var bestand = e_bestandInput[n].value();

		var data = {
			naam: name,
			beschrijving: desc,
      bestandnaam: bestand
		}

		var ref = database.ref('deelnemers');
		//ref.push(data);
		ref.child('/' + n).set(data);
	}
}

//Hier wordt alle HTML voor de eerste keer op de pagina gezet
function initializeHTML(){

		for(n = 0; n < nOfDeelnemers; n++){
		displayName[n] = 'Deelnemer ' + n.toString();

		//deelnemer div
		e_deelnemerDiv[n] = createDiv('');
		e_deelnemerDiv[n].parent('deelnemers');
		e_deelnemerDiv[n].id('deelnemer' + n.toString());

			//span
			e_collapseButtonSpan[n] = createSpan('');
			e_collapseButtonSpan[n].id('collapsebuttonspan' + n.toString());
			e_collapseButtonSpan[n].parent('deelnemer' + n.toString());

				//button
				e_collapseButton[n] = createButton('+');
				e_collapseButton[n].id('collapsebutton' + n.toString());
				e_collapseButton[n].parent('collapsebuttonspan' + n.toString());
				e_collapseButton[n].attribute('type', 'button');
				e_collapseButton[n].attribute('class', 'button');
				e_collapseButton[n].attribute('data-toggle', 'collapse');
				e_collapseButton[n].attribute('data-target', '#inputdiv' + n.toString());
				//button

				//header deelnemer name
				e_deelnemerName[n] = createElement('h4', displayName[n]);
				e_deelnemerName[n].parent('collapsebuttonspan' + n.toString());
				//header deelnemer name

			//span

			//input div
			e_inputDiv[n] = createDiv('');
			e_inputDiv[n].id('inputdiv' + n.toString());
			e_inputDiv[n].parent('deelnemer' + n.toString());
			e_inputDiv[n].attribute('class', 'collapse');

				//label naam
				e_nameLabel[n] = createElement('label', 'Naam: ');
				e_nameLabel[n].id('namelabel' + n.toString());
				e_nameLabel[n].parent('inputdiv' + n.toString());
				e_nameLabel[n].attribute('for', 'nameinput' + n.toString());
				//label naam

				//textarea naam
				e_nameInput[n] = createElement('textarea', retrievedData[n].naam);
				e_nameInput[n].id('nameinput' + n.toString());
				e_nameInput[n].parent('inputdiv' + n.toString());
				e_nameInput[n].attribute('class', 'form-control');
				e_nameInput[n].attribute('rows', '1');
				//textarea

				//label beschrijving
				e_descLabel[n] = createElement('label', 'Beschrijving: ');
				e_descLabel[n].id('descriptionlabel' + n.toString());
				e_descLabel[n].parent('inputdiv' + n.toString());
				e_descLabel[n].attribute('for', 'descriptioninput' + n.toString());
				//label beschrijving

				//textarea beschrijving
				e_descInput[n] = createElement('textarea', retrievedData[n].beschrijving);
				e_descInput[n].id('descriptioninput' + n.toString());
				e_descInput[n].parent('inputdiv' + n.toString());
				e_descInput[n].attribute('class', 'form-control');
				e_descInput[n].attribute('rows', '5');
				//textarea beschrijving

        //label bestandnaam
        e_bestandLabel[n] = createElement('label', 'Bestandsnaam van foto: ');
				e_bestandLabel[n].id('bestandlabel' + n.toString());
				e_bestandLabel[n].parent('inputdiv' + n.toString());
				e_bestandLabel[n].attribute('for', 'bestandinput' + n.toString());
        //label bestandnaam

        //textarea bestandsnaam
        e_bestandInput[n] = createElement('textarea', retrievedData[n].bestandnaam);
        e_bestandInput[n].id('bestandinput' + n.toString());
        e_bestandInput[n].parent('inputdiv' + n.toString());
        e_bestandInput[n].attribute('class', 'form-control');
        e_bestandInput[n].attribute('rows', '1');
        //textarea bestandsnaam

			//input div

		//deelnemer div

		}

		//button opslaan
		e_saveButton[n] = createButton('Opslaan');
		e_saveButton[n].id('savebutton' + n.toString());
		e_saveButton[n].attribute('type', 'button');
		e_saveButton[n].attribute('class', 'btn btn-info');
		e_saveButton[n].mousePressed(saveData);

		//button opslaan

    hasInitialized = true;
}
