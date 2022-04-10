import { GroceryListClass } from '../../DataFactory/Repository/GroceryListClass.js'
import { OverlayClass } from '../../Util/Components/Overlay.js'
import { GroceryItemModel } from '../../Model/GroceryItemModel.js'
import { CardOptions } from '../../Util/Components/CardOptions.js'
import { ChangeColors as Color } from '../../Util/CosmeticChanges/Colors/ChangeColors.js'
import { SuccessMessage } from '../../Model/SuccessMessage.js';


//variables
let RecommendedSuggestionContainer = document.getElementById('RecommendedSuggestionContainer');
let allSearchIcons = document.querySelectorAll('.SearchIcons');
let searchInputTxt = document.getElementById('searchInputTxt');
let Overlay = document.getElementById('Overlay');
let searchIconContainer = document.getElementById('searchIconContainer');
let cardContainer = document.getElementById('listContainer');
let sortButton = document.getElementById('submitSearchBtn');
let IconSearchArray = new Array();
let matchResults = new Array();
//Objects
let GroceryListOptions = new GroceryListClass();
let OverlayAfterAdd = new OverlayClass(Overlay, searchIconContainer);

//GroceryItem Model
let ownerId = $('#OwnerID').val();
let itemTitle;//Tile of Grocery Item user added
let searchIconTitle; //Awesome icon class namespace
let isComplete;
let PartnerID = $('#PartnerID').val() == null ? 0 : $('#PartnerID').val();
let GroceryModel = null;

var key = function (obj) {
    // Some unique object-dependent key
    return obj.totallyUniqueEmployeeIdKey; // Just an example
};

/*******************************Main Function*****************************************/



//This stores all the awesome Icon names to be used to search through
allSearchIcons.forEach(IconElement => {
    IconSearchArray.push(IconElement.getAttribute('title'));
});


//Creates initial GroceryList to Display
ShowUpdatedGroceryList(ownerId, PartnerID, cardContainer);
searchInputTxt.focus();

sortButton.addEventListener('click', function (e) {
    ShowUpdatedGroceryList(ownerId, PartnerID, cardContainer);
});

searchInputTxt.addEventListener('keyup', function (e) {
    searchIconContainer.scrollTo({ top: 0, behavior: "smooth" });
   
    if (searchInputTxt.value.length > 2) {
        matchResults = new Array();
        let userSearchInput = searchInputTxt.value.split(' ');
        IconSearchArray.findIndex(IconArrayItem => {

            userSearchInput.forEach(IconSearchElement => {
                //Makes takes aways the (s) in plural words
                if (IconSearchElement.charAt(IconSearchElement.length - 1 == 's')) {
                    IconSearchElement = IconSearchElement.slice(0, -1);
                }
                if (IconArrayItem.toUpperCase().includes(IconSearchElement.toUpperCase())) {
                    matchResults.push(IconArrayItem)

                }
            })
        });
        RecommendedSuggestionContainer.innerHTML = '';
        matchResults.forEach(matchResultItem => {
            RecommendedSuggestionContainer.insertAdjacentHTML('afterbegin', `<i class="${matchResultItem} SearchIcons RecommendIcons"  title="${matchResultItem}"></i>`)
        });
        let recommendElements = document.querySelectorAll(".RecommendIcons");
        for (let i = 0; i < recommendElements.length; i++) {
            recommendElements[i].addEventListener('click', function () {
                searchIconContainer.scrollTo({ top: 0, behavior: "smooth" });
                //Variables       
                itemTitle = searchInputTxt.value;
                searchIconTitle = recommendElements[i].getAttribute('title');
                isComplete = false;
                GroceryModel = new GroceryItemModel(0, ownerId, itemTitle, searchIconTitle, isComplete, PartnerID); //ID is 0..doesn't matter cause it's not used here

                //This clears the overlay and searchTXT field to show the application is attempting to add.
                searchInputTxt.value = "";
                OverlayAfterAdd.hideOverlay();
                searchInputTxt.focus();

                //Adds the item that was clicked on in the search container to the GroceryListDB
                //The Add Method will also add the ghost card while waiting for DB to respond
                let finishedAddingToGroceryList = GroceryListOptions.addToGroceryList(GroceryModel.ReturnGroceryItemModel());
                finishedAddingToGroceryList.then(function (resultMessage) {
                    if (resultMessage.ReturnStatus.toUpperCase() == 'SUCCESS'.toUpperCase()) {

                        //Get all update grocerylist And Get Updated groceryList
                        ShowUpdatedGroceryList(ownerId, PartnerID, cardContainer);
                       
                    }
                    else {
                        //Alert messsage will show up and display an error
                        alert(resultMessage.ReturnMessage);
                    }
                });
            });
        }
    }


    if (e.keyCode === 13 && searchInputTxt.value.toUpperCase() == '/delete'.toUpperCase()) {
        console.log("deleting..")
        searchInputTxt.value = "";
        searchInputTxt.focus();

        let deleteCompletedGroceryItems = GroceryListOptions.DeleteMyCompletedGroceryItem(ownerId, PartnerID);

        deleteCompletedGroceryItems.then(function (successMessage) {
            let resultMessage = new SuccessMessage(successMessage);
            //console.log(resultMessage);

            ShowUpdatedGroceryList(ownerId, PartnerID, cardContainer);
        });
    }

    
});

//Looping through all SearchIcons
for (let i = 0; i < allSearchIcons.length; i++) {

    //Listener: Attach onclickListeners to all SearchIcons
    allSearchIcons[i].addEventListener('click', function () {
        searchIconContainer.scrollTo({ top: 0, behavior: "smooth" });
        //Variables       
        itemTitle = searchInputTxt.value;
        searchIconTitle = allSearchIcons[i].getAttribute('title');
        isComplete = false; 
        GroceryModel = new GroceryItemModel(0, ownerId, itemTitle, searchIconTitle, isComplete, PartnerID); //ID is 0..doesn't matter cause it's not used here

        //This clears the overlay and searchTXT field to show the application is attempting to add.
        searchInputTxt.value = "";
        OverlayAfterAdd.hideOverlay();
        searchInputTxt.focus();

        //Adds the item that was clicked on in the search container to the GroceryListDB
        //The Add Method will also add the ghost card while waiting for DB to respond
        let finishedAddingToGroceryList = GroceryListOptions.addToGroceryList(GroceryModel.ReturnGroceryItemModel());
        finishedAddingToGroceryList.then(function (resultMessage) {
            
            if (resultMessage.ReturnStatus.toUpperCase() == 'SUCCESS'.toUpperCase()) {
                //Get all update grocerylist And Get Updated groceryList
                ShowUpdatedGroceryList(ownerId, PartnerID, cardContainer);
                
              
            }
            else {
                //Alert messsage will show up and display an error
                alert(resultMessage.ReturnMessage);
            }      
        });      
    });
}

/**************************Helper Functions*********************************/

/**
 * This method is in charge of getting the grocery list as well as attaching Listeners to each of the new items
 * @param {any} ownerId - Takes in current logged in user's ID
 * @param {any} PartnerID - Takes in User's Partner ID
 * @param {any} cardContainer - Takes in the container that all the cards are living in
 * 
 */
function ShowUpdatedGroceryList(ownerId, PartnerID, cardContainer) {

    //Grab the grocerylist to manipulate
    let groceryList = new CardOptions(cardContainer);
    
    
    //Gets all GroceryItems and returns a JSON Object of groceryItems
    let returnGroceryList = GroceryListOptions.getAllGroceryListItems(ownerId, PartnerID);
    returnGroceryList.then(function (GroceryListItems) {
        //Append each card AND attach listeners to them
        attachUpdateListnerToCards(GroceryListItems, groceryList, cardContainer);
        
        
    });
}



/**
 *  This Method is in charge of attaching listeners to all the new GroceryItems being passed into the GroceryListItems Param.
 *  It then takes the JSON list of the User's Grocery Items and appends the Cards/GroceryItems to the GroceryList Param.
 * @param {any} GroceryListItems - Takes in a list of all GroceryItems belonging to logged in user
 * @param {any} groceryList - Takes in a NewCard Option so it can create new cards and append to the grocerylist
 */
function attachUpdateListnerToCards(GroceryListItems, groceryList, cardContainer) {
    cardContainer.innerHTML = '';





    for (let i = 0; i < GroceryListItems.length; i++) {
            
        //Variables that make up a Grocery Model  
        let ID = GroceryListItems[i].ID;
        let ownerId = GroceryListItems[i].OwnerID;
        let itemTitle = GroceryListItems[i].ItemName;
        let searchIconTitle = GroceryListItems[i].IconName;
        let isComplete = GroceryListItems[i].isComplete;
        let PartnerID = GroceryListItems[i].PartnerID;

        //Object
        let GroceryItemClicked = new GroceryItemModel(ID, ownerId, itemTitle, searchIconTitle, isComplete, PartnerID);
        groceryList.AppendCard(GroceryItemClicked); //Appends cards, grabs the card that was just append, and attaches a listener to it
        let currentCard = document.getElementById(`GroceryItem${GroceryItemClicked.ID}`); //Attach listener to above card appended

        //Checking to see what color to mark the cards
        let GroceryItem = new Color(currentCard);
        GroceryItemClicked.isComplete ? GroceryItem.MarkComplete() : GroceryItem.MarkIncomplete();


        let currentCardLoadingOverlay = document.getElementById(`cardOverlay${GroceryItemClicked.ID}`)

        //Listner: Update GroceryList by changing it's color
        currentCard.addEventListener('click', function (e) {




             // Update to the database and display a loading overlay on card when success remove loading overlay on card
            if (GroceryItemClicked.isComplete) {

                //If GrcoeryItem is currently complete then user is trying to undo a complete option so we need to change it to false in the DB
                GroceryItemClicked.isComplete = false;
                let GroceryItemUpdated = GroceryListOptions.UpdateMyGroceryItem(GroceryItemClicked, currentCardLoadingOverlay);
                GroceryItemUpdated.then(function () { //Change its color to Purple
                    let finishedCard = new Color(currentCard);
                    finishedCard.MarkIncomplete();
                    
                });

                //These TODO's will go in the update statement
                //TODO: If success and iscomplete is false then turn the card yellow
            }
            else {
                //Since currently user is trying to cross off item we need to change the status to complete
                GroceryItemClicked.isComplete = true;
                let GroceryItemUpdated = GroceryListOptions.UpdateMyGroceryItem(GroceryItemClicked, currentCardLoadingOverlay);
                GroceryItemUpdated.then(function () {//Change its color to Yellow
                    let finishedCard = new Color(currentCard);
                    finishedCard.MarkComplete();
                   
                });                          
            }
        });
    }

}

