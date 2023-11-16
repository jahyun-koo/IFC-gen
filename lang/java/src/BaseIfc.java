import java.util.UUID;
import com.howbuild.ifc.v4.ConvertibleToStep;

public abstract class BaseIfc implements ConvertibleToStep {
  private UUID id;
  private int stepId;

  public BaseIfc() {
    this.id = UUID.randomUUID();
  }

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

  public UUID getId() {
    return id;
  }

  public void setId(UUID id) {
    this.id = id;
  }

  public int getStepId() {
    return stepId;
  }

  public void setStepId(int stepId) {
    this.stepId = stepId;
  }
}
