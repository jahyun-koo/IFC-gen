import java.util.Base64;
import java.util.UUID;

public abstract class BaseIfc implements ConvertibleToStep {
    private String id;
    private int stepId;

    public BaseIfc() {
        // Create a new UUID
        UUID uuid = UUID.randomUUID();

        // Convert the UUID to a byte array
        byte[] bytes = new byte[16];
        long msb = uuid.getMostSignificantBits();
        long lsb = uuid.getLeastSignificantBits();
        for (int i = 0; i < 8; i++) {
            bytes[i] = (byte) ((msb >> 8 * (7 - i)) & 0xFF);
            bytes[i + 8] = (byte) ((lsb >> 8 * (7 - i)) & 0xFF);
        }

        // Encode the byte array as a Base64 string
        String base64Uuid = Base64.getEncoder().withoutPadding().encodeToString(bytes);

        // Replace the unsupported characters
        this.id = base64Uuid.replace('/', '_').replace('+', '-');
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

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public int getStepId() {
        return stepId;
    }

    public void setStepId(int stepId) {
        this.stepId = stepId;
    }
}
