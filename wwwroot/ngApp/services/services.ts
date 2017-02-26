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

    //export class EditModalService {
    //    constructor(public $uibModal: ng.ui.bootstrap.IModalService) { }
    //    public editModal(html, budgetId = 0, goalId = 0) {
    //        this.$uibModal.open({
    //            templateUrl: `/ngApp/views/${html}`,
    //            controller: newBudgetBook.Controllers.ModalController,
    //            controllerAs: "modal",
    //            resolve: {
    //                budgetId: () => budgetId,
    //                goalId: () => goalId
    //            },
    //            size: 'md'
    //        });
    //    }
    //}

    angular.module("newBudgetBook").service("ModalService", ModalService);

    }
