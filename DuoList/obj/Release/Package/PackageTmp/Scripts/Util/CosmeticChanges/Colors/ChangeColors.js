export class ChangeColors {

    //Expects a container element
    constructor(Container) {
        this.Container = Container;
    }

    //Change Grocery Card to Yellow and removes the Purple background color
    MarkComplete() {
        this.Container.classList.add('Yellow');
        this.Container.classList.remove('Purple');
    }

    //Change Card element container to Purple and removes the Yellow "Complete" color
    MarkIncomplete() {
        this.Container.classList.add('Purple');
        this.Container.classList.remove('Yellow');
    }
}