export class GroceryItemModel{

    /**
     * 
     * @param {int} ownerId - The Loged In User's ID. This will be an Int.
     * @param {any} itemTitle - Takes in the Grocery Item Name that the user enters in the search box.
     * @param {any} searchIconTitle - This is the grocery Icon that is clicked
     * @param {boolean} isComplete - Takes in a boolean. True if grocery item is checked off, False if item isn't check off.
     * @param {string} PartnerID - Takes in a string representation of an INT.
     */
    constructor(ID, ownerId, itemTitle, searchIconTitle, isComplete, PartnerID) {
        this.ID = ID,
        this.ownerId = ownerId;
        this.itemTitle = itemTitle;
        this.searchIconTitle = searchIconTitle;
        this.isComplete = isComplete;
        this.PartnerID = PartnerID;
    }

    //Returns a GroceryItemModel
    ReturnGroceryItemModel() {
        let GroceryObject = {
            ID: this.ID,
            OwnerID: this.ownerId,
            ItemName: this.itemTitle,
            IconName: this.searchIconTitle,
            isComplete: this.isComplete,
            PartnerID: this.PartnerID
        }
        return GroceryObject;
    }
}