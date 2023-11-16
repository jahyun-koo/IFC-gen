public interface ConvertibleToStep {
  String toStepValue(boolean isSelectOption);
  default String toStepValue() {
    return toStepValue(false);
  }
}
