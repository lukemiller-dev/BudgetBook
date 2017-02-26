namespace newBudgetBook.Controllers {

    export class HomeController {
        public budgets;
        public sideIcon = true;
       
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModal: ng.ui.bootstrap.IModalService, public ModalService: newBudgetBook.Services.ModalService) {
            $http.get('api/budgets').then((res) => {
                this.budgets = res.data;
            })
            
        }
       
        public openNav() {
            this.sideIcon = false;
            console.log("Test");                     
            document.getElementById("sidenav").style.width = "230px"; 
        
            document.getElementById("homeNavBar").style.marginRight = "300px";
       
                 
    }

        public closeNav() {
            this.sideIcon = true;
            document.getElementById("sidenav").style.width = "0";  
     
            document.getElementById("homeNavBar").style.marginRight = "0";
        }

       

        public toTop() {
            window.scroll(0, 0);
        }
    }

    
    

    export class ModalController {
        public budget;
        public eCurrent;
        public eName;
        public eAmount;
        public goals;
        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance) { }

        public addBudget(budget) {
            this.$http.post('api/budgets', budget).then((res) => {
                this.$state.reload();
            })
        }

        public addGoal(goal) { 
                    
                    this.$http.post('api/goals', goal).then((res) => {
                        this.$state.reload();                                   
                })          
        }

       
        public closeModal() {
            this.$uibModalInstance.close();
        }
    }

    export class mainAccountController {
        public maBudgets;
        public appUserIncome;
        public monthlyIncome;
        public current;
        public sCurrent;
        public goals;
        public gCurrent;
        public eIncome;
        public menuOption = true;
        public hideAddInput = true;
        public hideSubtractInput = true;
        public subtractIcon = false;
        public addIcon = false;
        public gAddInput = true;
        public gSubtractInput = true;
        public gSubtractIcon = false;
        public gAddIcon = false;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModal: ng.ui.bootstrap.IModalService, public ModalService: newBudgetBook.Services.ModalService, public $stateParams: ng.ui.IStateParamsService) {
            $http.get('api/budgets').then((res) => {
                this.maBudgets = res.data;
            })
            $http.get('api/appUsers').then((res) => {
                this.appUserIncome = res.data;
            })
            $http.get('api/goals').then((res) => {
                this.goals = res.data;
            })
        }

        public addIncome() {         
            this.$http.post('api/appUsers', this.monthlyIncome).then((res) => {             
                this.$state.reload();
            })
        }

        public editIncome() {
            this.$http.put('api/appUsers/editAmount', this.eIncome).then((res) => {
                this.$state.reload();
            })
        }

        public addToCurrent(budgetId) {
            console.log(budgetId);
            console.log(this.current);

            this.hideAddInput = !this.hideAddInput;
            this.subtractIcon = !this.subtractIcon;
            this.$http.post(`api/budgets/amount/${budgetId}`, this.current).then((res) => {
                this.$state.reload();
            })
        }

        public subtractCurrent(budgetId) {
            this.hideSubtractInput = !this.hideSubtractInput;
            this.addIcon = !this.addIcon;

            this.$http.put(`api/budgets/amount/${budgetId}`, this.sCurrent).then((res) => {
                this.$state.reload();
            })
        }

        public moveSubtractIcon() {
            this.hideSubtractInput = !this.hideSubtractInput;
            this.addIcon = !this.addIcon;
        }

     

        public deleteBudget(id) {
            this.$http.delete(`api/budgets/${id}`).then((res) => {
                this.$state.reload();
            })
        }

        public openModal(html) {
            this.ModalService.openModal("addBudgetModal.html");        
        }

        public openGoalModal(html) {
            this.ModalService.openModal("goalModal.html");
        }

        public editBudgetModal(html) {
            this.ModalService.openModal("editBudget.html");
        }

        public openCollapse() {  
            this.menuOption = false; 
            document.getElementById('hamburger').style.width= "50%";     
        
     
        }

        public closeCollapse() {
            this.menuOption = true;
            document.getElementById('hamburger').style.width = "0";
           
        }


        //ProgressBar Methods
     

        //goal methods

        public addToGoal(goalId) {
            this.gAddInput = !this.gAddInput;
            this.gSubtractIcon = !this.gSubtractIcon;
            this.$http.post(`api/goals/amount/${goalId}`, this.gCurrent, this.monthlyIncome).then((res) => {
                this.$state.reload();
            })
        }

        public subtractGoal(goalId) {
            
            this.gSubtractInput = !this.gSubtractInput;
            this.gAddIcon = !this.gAddIcon;
            this.$http.put(`api/goals/amount/${goalId}`, this.gCurrent, this.monthlyIncome).then((res) => {
                this.$state.reload();
            })
        }

      

        public deleteGoal(id) {
            this.$http.delete(`api/goals/${id}`).then((res) => {
                this.$state.reload();
            })
        }

       
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
