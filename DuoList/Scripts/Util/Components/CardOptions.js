export class CardOptions {
    /**
     * This will take in a container Element and append Cards to that List container. 
     * @param {any} containerAppendingTo - Takes in a container to append the cards to. In the Grocery Index It's the GrocieryList Element
     */
    constructor(containerAppendingTo) {
        this.Container = containerAppendingTo;
    }

    //Takes the already made ghost card from method in here and appends it to the containerAppendingTo element passed in
    appendGhostCard() {
        this.CurrentGhostCard = this.ghostCardCard();
        this.Container.insertAdjacentHTML('afterbegin', this.CurrentGhostCard);
    }

    //Removes the already made ghost card from method in here and appends it to the containerAppendingTo element passed in
    removeGhostCard() {
       
        let ghostCard = document.querySelector(`.activeGhostCard${this.cardNumber}`);
        ghostCard.remove();

    }

    //Takes the already made card from method in here and appends it to the containerAppendingTo element passed in
    AppendCard(id) {
        this.Card = this.CreateCard(id);
        this.Container.insertAdjacentHTML('afterbegin', this.Card)
        return this.Card;
    }

    /****************************Private Methods************************************** */
    //Private: Creates a ghost card or loading card. It's a loading card to use when adding a new Grocery item to the database
    ghostCardCard() {
        this.cardNumber = Math.floor(Math.random() * 10000) + 1;
        let ghostCard =
            `<div class="ghostCard activeGhostCard${this.cardNumber}">
                    <div id="loadingContainer">
                        <div id="dot-1" class="loadingDot growAndShrink"> </div>
                        <div id="dot-2" class="loadingDot growAndShrinkDelayTwoHundredMillisecones"> </div>
                        <div id="dot-3" class="loadingDot growAndShrinkDelayFourHundredMillisecones"> </div>
                    </div>
                    <h4 class="changeLoadingColors">Adding...</h4>
                </div>`

        return ghostCard
    }

    //Private: Creates a  card to be loaded to the database
    //GroceryListItems - Takes in a user's GroceryList 
    CreateCard(GroceryItemModel) {
        let card =
            `<div id="GroceryItem${GroceryItemModel.ID}" isComplete=${GroceryItemModel.isComplete} class="card">
                <div id="cardOverlay${GroceryItemModel.ID}" class="cardOverlay  hide">
                    <div>
                        <div id="dot-1" class="loadingDot growAndShrink"> </div>
                        <div id="dot-2" class="loadingDot growAndShrinkDelayTwoHundredMillisecones"> </div>
                        <div id="dot-3" class="loadingDot growAndShrinkDelayFourHundredMillisecones"> </div>
                    </div>
                    <h4 class="changeLoadingColors" id="updateClickOverlayTxt">Updating</h4>
                </div>
                <i class="${GroceryItemModel.searchIconTitle} GroceryListIcons"></i>
                <h4 class="cardTitle">${GroceryItemModel.itemTitle}</h4>
            </div>`
        return card
    }

}