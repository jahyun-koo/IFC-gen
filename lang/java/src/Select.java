/*
 * A SELECT data type defines a named collection of other data types. These may be other entities,
 * a list of string values, a list of real values etc. As with enumeration’s, only one item from a
 * SELECT list is used by an instance of the class which uses the TYPE.
 * <code>
 * TYPE IfcBuildingSelect = SELECT
 *   (IfcBuilding, IfcBuildingStorey);
 * END_TYPE;
 * </code>
 */
public interface Select {}
