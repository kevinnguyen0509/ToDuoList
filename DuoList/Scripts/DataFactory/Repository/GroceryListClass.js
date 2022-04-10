import { CardOptions } from '../../Util/Components/CardOptions.js'

let cardContainer = document.getElementById('listContainer');
let ghostCard = new CardOptions(cardContainer);
let baseUrl = document.getElementById('HiddenCurrentUrl').value;

export class GroceryListClass {

    constructor() {
        this.baseUrl = baseUrl
    }

    /**
     * This is the Ajax call to add A GroceryItem to the list
     * @param {any} GroceryItemModel - Takes in A GroceryItemModel to be added to the database
     */
    async addToGroceryList(GroceryItemModel) {
        //Shows ghost card to user giving feedback that it's being added to the database
        ghostCard.appendGhostCard(cardContainer);
       
       return await $.ajax({
            type: "POST",
            url: this.baseUrl + 'JsonGrocery/SaveGroceryItem',
            data: { GroceryItemModel},
           success: function (data) {
               
                return data;
            },
            error: function (request, status, error) {
                console.log("Problem adding Grocerylist: " + request.responseText);
                
            }
        });
    }

    /**
     * This will get all the GroceryList that belong to the logged in user
     * @param {int} OwnerId - Takes in the UserID
     * @param {any} PartnerId - Takes in a string representation of ParternerID Integer
     */
    async getAllGroceryListItems(OwnerId, PartnerId) {
        return await $.ajax({
            type: "POST",
            url: this.baseUrl + 'JsonGrocery/GetMyGroceryList',
            data: {
                OwnerID: OwnerId,
                PartnerID: PartnerId
            },
            success: function (data) {
                //We don't need to remove ghost card because whole list refreshes
                return data;
            },
            error: function (request, status, error) {
                console.log("Problem adding Grocerlist: " + request.responseText);

            }
        });
    }

    /**
     * This will "Cross off item" on the list Or "Put them back" on the list
     * @param {any} GroceryItemModel - Expects A GroceryItem to be passed in
     * @param {any} currentCardLoadingOverlay - Expects The Overlay thats with a card to be passed
     */
    async UpdateMyGroceryItem(GroceryItemModel, currentCardLoadingOverlay) {
        currentCardLoadingOverlay.classList.remove('hide');//display the loading overlay on card

        return await $.ajax({
            type: "POST",
            url: this.baseUrl + 'JsonGrocery/UpdateMyGroceryItem',
            data: { GroceryItemModel },
            success: function (data) {
                currentCardLoadingOverlay.classList.add('hide');//Hide the loading overlay on card
                return data;
            },
            error: function (request, status, error) {
                console.log("Problem adding Grocerlist: " + request.responseText);
                alert(request.responseText);
            }
        });
    }

    /**
     * Deletes All Completed Grocery Items for the logged in user and their partnerID 
     * @param {any} OwnerID - Logged in user's ID
     * @param {any} PartnerID Logeed in user's PartnerID
     */
    async DeleteMyCompletedGroceryItem(OwnerID, PartnerID) {
       
        return await $.ajax({
            type: "Post",
            url: this.baseUrl + 'JsonGrocery/DeleteCompletedGroceryItem',
            data: { OwnerID, PartnerID },
            success: function (data) {
               
                return data;
            },
            error: function (request, status, error) {
                console.log("Problem adding Grocerlist: " + request.responseText);
                alert(request.responseText);
            }
        });
    }
}

