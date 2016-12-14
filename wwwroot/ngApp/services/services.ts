namespace newBudgetBook.Services {
    export class ModalService {
        constructor(public $uibModal: ng.ui.bootstrap.IModalService) { }
        public openModal(html) {
            this.$uibModal.open({
                templateUrl: `/ngApp/views/${html}`,
                controller: newBudgetBook.Controllers.ModalController,
                controllerAs: 'modal',
                size: 'md'
            });
        }
    }

    angular.module("newBudgetBook").service("ModalService", ModalService);
    }
