import {BaseIfc} from "./BaseIfc"

export abstract class Select extends BaseIfc {
    protected value: any

    toXML(xw: any): void {
        xw.text(this.value.toString())
    }

    toStepValue(isSelectOption: boolean = false): string {
        {
            return this.value.toStepValue(true);
        }
    }

    toSTEP(): string {
        {
            return `${this.value.stepId} = ${this.constructor.name.toUpperCase()}(${this.value.getStepParameters()})`
        }
    }
}