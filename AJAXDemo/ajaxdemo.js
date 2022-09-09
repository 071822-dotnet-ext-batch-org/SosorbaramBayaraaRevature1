"use strict;"

const xhr = new XMLHttpRequest();
console.log(`The readystate is ${xhr.readyState}`);

xhr.onreadystatechange = () => {
    console.log(`The readystate is ${xhr.readyState} - ${xhr.status}`)
    if (xhr.readyState == 4 && xhr.status == 200)  {
        console.log(`the resonse text is ${xhr.responseType}`);
        console.log(`The responsetext is ${xhr.responseText}`);
        displayResponseTextInBrowser()

    }
    else {
        console.log(`Jokes are not ready yet`)
    }
}

xhr.open('GET' ,'http://api.icndb.com/jokes/random', true);
xhr.send();
// I want a div that I can put p elemtns
// into to display the joke text
function displayResponseTextInBrowser() {
    //get the body object
    let bodie = document.body;
    //create the div
    let myDiv = document.createElement('div');
    //create the p element
    let myP = document.createElement('p');
    //add the div and p to the html
    myDiv.appendChild(myP);
    bodie.appendChild(myDiv);
//convert the JSON string into JS object
    let restText = JSON.parse(xhr.responseText);
    console.log(restText)
    //add the text to the p element
    myP.textContent = restText.value.joke;

}

// now get 5 Jokes
const xhr2 = new XMLHttpRequest();
console.log(`The readystate is ${xhr2.readystate}`);
xhr2.onreadystatechange = () => {
  if (xhr2.readyState == 4 && xhr2.status == 200) {
    displyJokesInBrowser();
  }
  else {
    console.log(`Jokes are not ready yet!`);
  }
};
let five = 5;

xhr2.open('GET', `http://api.icndb.com/jokes/random/${Math.floor(Math.random()*6)}`, true);
xhr2.send();

function displayResponseTextInBrowser() {

  console.log(xhr2.responseText);
    let bodie = document.body;
  //get the new div element
  //let myDiv = document.createElement('div');
  //convert the JSON string into a JS object
  let myP = document.createElement('p')
  // let resText = JSON.parse(xhr.responseText);
  //console.log(resText)
  myDiv.appendChild(myP1);
  bodie.appendChild(myDiv);

  let restText1 = JSON.parse(xhr2.responseText);
  console.log(restText1)
  let count=1;
  for(const x of response.value) {
    myP.textContent += `${count++}` + ` `+ `${x.joke}` + `\n`;
  }

}