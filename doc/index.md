JsonMM Documentation
====================

JsonMM currently has two top methods :

- [application](application/index.md)
- [player](player/index.md)

Each request to JsonMM returns a status code and either an error or a result object.

```javascript
{
	status: 0,
	result: {/*some result*/}
}
```

You can learn more about [status code, errors and exceptions](status_code_errors.md)