import { OverlayClass } from '../../Util/Components/Overlay.js'
let searchInputTxt = document.getElementById('searchInputTxt');
let searchIconContainer = document.getElementById('searchIconContainer');
let OverlayContainer = document.getElementById('Overlay');

//Classes Being Instantiated
const IndexOverlay = new OverlayClass(OverlayContainer, searchIconContainer);
    
$(document).ready(function () {

    //Listener: If nothing is in the textbox take it away, else show overlay of grocery items
    searchInputTxt.addEventListener('keyup', function () {
        if (searchInputTxt.value.trim() == '') {
            IndexOverlay.hideOverlay();
        } else {
            IndexOverlay.showOverlay();
        }       
    });

    //Listener: Clicking on the overlay will dismiss the overlay
    OverlayContainer.addEventListener('click', function () {
        IndexOverlay.hideOverlay();
    })
})



