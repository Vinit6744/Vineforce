export class Country {
    countryId: number | undefined | null
    countryName: string | undefined | null

    constructor() {
        this.countryId = 0,
            this.countryName = ""
    }

}

export class State {
    stateId : number | undefined | null
    stateName : string | undefined | null
    countryId : number | undefined | null
    

    constructor() {
        this.stateId=0;
        this.countryId = 0;
        this.stateName = "";
    }

}