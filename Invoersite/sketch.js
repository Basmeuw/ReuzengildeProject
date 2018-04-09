let n = 0;
var _n;
var nOfDeelnemers = 15;

//vars
var displayName = [];
var name = [];
var description = [];

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
var e_saveButton = [];

var collapsebutton = [];

//firebase
var database;


function setup() {

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

	initializeHTML();

  for(var i = 0; i < nOfDeelnemers; i++){
    var ref = database.ref('deelnemers/' + i);
    ref.on('value', function(snap){
      name[i] = snap.naam.val();
      description[i] = snap.beschrijving.val();
    });
  }


}

function saveData(){
	for(n = 1; n <= nOfDeelnemers; n++){
		var name = e_nameInput[n].value();
		var desc = e_descInput[n].value();

		var data = {
			naam: name,
			beschrijving: desc
		}

		var ref = database.ref('deelnemers');
		//ref.push(data);
		ref.child('/' + n).set(data);
	}
}

//
// function getDataFromDeelnemer(n){
//   var ref = database.ref('deelnemers/' + n);
//   ref.once('value').then(function (snap){
//     var data = {
//       naam: snap.val().naam,
//       beschrijving: snap.val().beschrijving
//     };
//     return data;
//   });
//
//
// }


function initializeHTML(){



		for(n = 1; n <= nOfDeelnemers; n++){
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
				e_nameInput[n] = createElement('textarea', '');
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
				e_descInput[n] = createElement('textarea', '');
				e_descInput[n].id('descriptioninput' + n.toString());
				e_descInput[n].parent('inputdiv' + n.toString());
				e_descInput[n].attribute('class', 'form-control');
				e_descInput[n].attribute('rows', '5');
				//textarea beschrijving

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

}
