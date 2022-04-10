export class OverlayClass {

    /**
     * This is used to easily show and hide a single overlay and a single Container element on the page.
     * @param {any} OverlayElement - Overlay Element located on the page
     * @param {any} ContainerElement - Takes in a Container Element such as the search container in the index
     */
    constructor(OverlayElement, ContainerElement) {
        this.OverlayElement = OverlayElement;
        this.ContainerElement = ContainerElement;
    }

    //Shows Overlay that is passed to the constructor
    //Shows Search Container and fades it in
    showOverlay() {
        this.OverlayElement.classList.add('FadeInFiftyPercent');
        this.OverlayElement.classList.remove('hide');

        this.ContainerElement.classList.add('FadeInSearchContainer');
        this.ContainerElement.classList.remove('hide');
        this.ContainerElement.classList.remove('shrinkSearchContainerAway');
       

    }

    //Hides Overlay passed to constructor
    //Hides Search Container and fades it in
    hideOverlay() {
        this.OverlayElement.classList.add('hide');
        this.OverlayElement.classList.remove('FadeInFiftyPercent');
     
        this.ContainerElement.classList.remove('FadeInSearchContainer');
        this.ContainerElement.classList.add('shrinkSearchContainerAway');
    }
}