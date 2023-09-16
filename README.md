# Vptcoder.TypeHandler

## Simple Usage
```cs
TypeHandler handler = new TypeHandler();
decimal value;

// like this
value = handler.ChangeType<decimal>(i.Value);
// or like this
value = (decimal)handler.ChangeType(i.Value, typeof(decimal));

```
## Usage
### 1. Prepare parameters object[] for Invoke method

### 2. Map DataSet to object/ object[]
