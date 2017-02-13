# Primayer Xilog API documentation

Questions? Find us at [@primayer](http://www.primayer.com/enquiry-form)

# Xilog Data Access

Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo.

# Methods

- [*getdata*](#getdata-options): Returns data for logger channel specified by date time range.
- [*getheader*](#getheader-options): Returns header data for logger channel.
- [*getnewdata*](#getnewdata-options): Returns last batch of channel data sent from logger.
- [*confirmdownload*](#confirmdownload-options): Returns the status code of last transaction sent from logger.

# API

#### For more in depth examples of the API, see the [`examples`](examples) folder.

## getdata(siteId, channelID, token, startDate, endDate, timeWindowStart, timeWindowEnd)

##### Purpose
Accepts a firebase configuration object as the first argument and an optional 'name' for the app as the second

##### Arguments
  1. configuration
    - type: object
    - properties:
      - apiKey (string - required) your firebase API key
      - authDomain (string - required) your firebase auth domain
      - databaseURL (string - required) your firebase database root URL
      - storageBucket (string - optional) your firebase storage bucket
      - messagingSenderId: (string - optional) your firebase messaging sender id
  2. app name
    - type: string (optional, defaults to '[DEFAULT]')

##### Return Value
  An instance of re-base.

##### Example

```javascript
var Rebase = require('re-base');
var base = Rebase.createClass({
      apiKey: "apiKey",
      authDomain: "projectId.firebaseapp.com",
      databaseURL: "https://databaseName.firebaseio.com",
      storageBucket: "bucket.appspot.com",
      messagingSenderId: "xxxxxxxxxxxxxx"
}, 'myApp');
```

<br />
