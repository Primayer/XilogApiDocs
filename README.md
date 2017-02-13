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

#### For more in depth C# and JavaScript examples of the API, see the [`examples`](examples) folder.

## getdata(siteID, channelID, token, startDate, endDate, timeWindowStart, timeWindowEnd)

##### Purpose
Accepts a firebase configuration object as the first argument and an optional 'name' for the app as the second

##### Signature
  1. Endpoint
    - http://api.primayer.com/api/xilog/getdata
  2. Params
    - siteID: (string - required)
      - logger site id as displayed on device.
    - channelID: (string - required)
      - specifies which channel's data should be returned.  
    - token: (string - required)
      - api authorization token.
    - startDate: (string - optional)
      - Date at which to start querying loggers channel data.
    - endDate: (string - optional)
      - Date at which to finish querying loggers channel data.
    - timeWindowStart: (string - optional)
      - Time at which to start querying loggers channel data.
    - timeWindowEnd: (string - optional)
      - Time at which to finish querying loggers channel data.
      

##### Return Value
  An object which contains an array of the loggers channel data:

```javascript
[{
  Timestamp: string,
  Value: number
}]
```


##### Example

```javascript
const path = 'http://api.primayer.com/api/xilog/getdata?siteID=serial_number&channelID=channel_index&token=token&startDate=s_date&endDate=e_date&timeWindowStart=s_time&timeWindowEnd=f_time'

fetch(path).then(function(response) {
    console.log(response)
})
```

<br />
