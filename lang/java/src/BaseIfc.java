import java.util.Base64;
import java.util.UUID;

public abstract class BaseIfc implements ConvertibleToStep {
    private int stepId;

    public BaseIfc() {}

    public String toStep() {
        String ifcClass = getClass().getName().toUpperCase();
        return "#" + stepId + " = " + ifcClass + "(" + this.getStepParameters() + ");";
    }

    @Override
    public String toStepValue(boolean isSelectOption) {
        return "#" + stepId;
    }

    @Override
    public String toStepValue() {
        return toStepValue(false);
    }

    public String getStepParameters() {
        return "";
    }

    public int getStepId() {
        return stepId;
    }

    public void setStepId(int stepId) {
        this.stepId = stepId;
    }
}
