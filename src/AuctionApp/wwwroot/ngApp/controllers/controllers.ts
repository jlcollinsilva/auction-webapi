namespace AuctionApp.Controllers {

    export class HomeController {
        //Controller for the Add and Search options in the main screen

        private ItemAuctionResource;

        public itemauction; //For one item
        public itemsauction; //For a list of items
        
        public validationErrors; 


       
        //Get a list of items
        public getItemAuction() { 
            this.itemsauction = this.ItemAuctionResource.query();
            console.log(this.itemsauction);
        }

        //Save a new item and update the list on the screen
        public save() {
            this.ItemAuctionResource.save(this.itemauction).$promise.then(() => {
                this.itemauction = null;
                this.validationErrors = null;
                this.getItemAuction();
            }).catch((err) => {

                let validationErrors = [];
                for (let prop in err.data) {
                    let propErrors = err.data[prop];
                    validationErrors = validationErrors.concat(propErrors);
                }
                this.validationErrors = validationErrors;
            });
        }

        //Control the function for to open the Modal for a new Bid registration
        public bid(id:any)
        {

            var iAuction = this.ItemAuctionResource.get({ id: id });
            this.showmodalbid(iAuction)
        }

        //Perform the Open Modal function
        public showmodalbid(auctionData:any) {
            
            var modalEnvironment = this.$uibModal.open({
                templateUrl: '/ngApp/views/bid.html',
                controller: 'BidController', //See definition and details ahead (below)
                controllerAs: 'modal',
                resolve: {
                    auctionData: () => auctionData //Parameter for to show the selected Item to Bid
                },
                size: 'md'
            })
            
            }

        constructor(private $resource: angular.resource.IResourceService,
            private $http: ng.IHttpService, private $uibModal: angular.ui.bootstrap.IModalService)
        {
            this.ItemAuctionResource = $resource('/api/auctionitem/:id');
            this.getItemAuction();
        }
    }//End of the Controller: HomeController

    //Controller specific for the Modal view/instance/scope
    class BidController  {

        private BidItemResource;

        public bidauctionitem;

        public bidItem;

        public validationErrors;

        public getItemBid(id) {
            this.bidItem = this.BidItemResource.get(id);
            console.log(this.bidItem);
        }

        //Save a new Bid for a specific Item
        public save() {
         
            this.BidItemResource.save(this.bidItem).$promise.then(() => {
                this.bidItem = null;
                this.validationErrors = null;
                this.$uibModalInstance.close(); 
            }).catch((err) => {
                let validationErrors = [];
                for (let prop in err.data) {
                    let propErrors = err.data[prop];
                    validationErrors = validationErrors.concat(propErrors);
                }

                this.validationErrors = validationErrors;
                //alert(this.validationErrors.join("")); //Show validation error to user

            });
        }

        constructor(private $resource: angular.resource.IResourceService,
            public auctionData: any, private $uibModal: angular.ui.bootstrap.IModalService,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $http: ng.IHttpService)
        {
            console.log(auctionData);
            this.BidItemResource = $resource('/api/bids/:id');
            this.bidItem = { itemAuction: auctionData };

            console.log(this.bidItem);
        }

        //Just for to close the Modal view.
        public closeDialog($uibModalInstance)
        {
            this.$uibModalInstance.close(); 
        }

    } //End of the Controller: "BidController"

    //Registration in the application of the Controller associated to the Modal.
    angular.module('AuctionApp').controller('BidController', BidController);

}