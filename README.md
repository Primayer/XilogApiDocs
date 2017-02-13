# Primayer Xilog API documentation

Questions? Find us at [development@primayer.com](mailto:development@primayer.com)

# Xilog Data Access

The Primayer API provides access to the raw data recorded by the Xilog logger. To use the API third parties must provide an authorization token with each request. The authorization token can be found within the settings section of [PrimeWeb](http://cloud.primayer.com). 

# Methods

- [*getdata*](#getdatasiteid-channelid-token-startdate-enddate-timewindowstart-timewindowend): Returns data for logger channel specified by date time range.
- [*getheader*](#getheadersiteid-channelid-token): Returns header data for logger channel.
- [*getnewdata*](#getnewdatasiteid-channelid-token): Returns last batch of channel data sent from logger.
- [*confirmdownload*](#confirmdownloadsiteid-channelid-token-lastdatetime-downloadsuccess): Returns the status code of last transaction sent from logger.

# API

#### For more in depth C# and JavaScript examples of the API, see the [`examples`](examples) folder.

## getdata(siteID, channelID, token, startDate, endDate, timeWindowStart, timeWindowEnd)

##### Purpose
Returns a collection of the raw channel data for the specified Xilog logger.

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
    // [{Timestamp: "01/10/2015 09:00:00", Value: 11000.0000}, {Timestamp: "01/10/2015 09:10:00", Value: 11089.0000}, {Timestamp: "01/10/2015 09:20:00", Value: 11780.0000}...]
})
```

<br />

## getheader(siteID, channelID, token)

##### Purpose
Returns the meta data associated with the Xilog logger data channel.

##### Signature
  1. Endpoint
    - http://api.primayer.com/api/xilog/getheader
  2. Params
    - siteID: (string - required)
      - logger site id as displayed on device.
    - channelID: (string - required)
      - specifies loggers channel.  
    - token: (string - required)
      - api authorization token.
      
##### Return Value
  An object containing meta data for channel:

```javascript
{
   Type: string,
   ReadingsType: string,
   Units: string,
   Interval: number
}
```

##### Example

```javascript
const path = 'http://api.primayer.com/api/xilog/getheader?siteID=serial_number&channelID=channel_index&token=token'

fetch(path).then(function(response) {
    console.log(response)
    // {Type: '', ReadingsType: '', Units: '', Interval: '']
})
```

<br />

## getnewdata(siteID, channelID, token)

##### Purpose
Returns the last batch of data sent from the logger for the specified channel.

##### Signature
  1. Endpoint
    - http://api.primayer.com/api/xilog/getnewdata
  2. Params
    - siteID: (string - required)
      - logger site id as displayed on device.
    - channelID: (string - required)
      - specifies loggers channel.  
    - token: (string - required)
      - api authorization token.


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
const path = 'http://api.primayer.com/api/xilog/getnewdata?siteID=serial_number&channelID=channel_index&token=token'

fetch(path).then(function(response) {
    console.log(response)
    // [{Timestamp: "01/10/2015 09:00:00", Value: 11000.0000}, {Timestamp: "01/10/2015 09:10:00", Value: 11089.0000}, {Timestamp: "01/10/2015 09:20:00", Value: 11780.0000}...]
})
```

<br />

## confirmdownload(siteID, channelID, token, lastDateTime, downloadSuccess)

##### Purpose
Returns the current status of the loggers channel.

##### Signature
  1. Endpoint
    - http://api.primayer.com/api/xilog/confirmdownload
  2. Params
    - siteID: (string - required)
      - logger site id as displayed on device.
    - channelID: (string - required)
      - specifies loggers channel.  
    - token: (string - required)
      - api authorization token.
    - lastDateTime: (string - required)
      - UK formatted string MM/dd/yyyy
    - downloadSuccess: (bool - required)
 
##### Return Value
  A status object for the loggers channel data:

```javascript
[{
  ErrorCode: string,
  ErrorDescription: string,
  Success: bool
}]
```

##### Example

```javascript
const path = 'http://api.primayer.com/api/xilog/confirmdownload?siteID=serial_number&channelID=channel_index&token=token&lastDateTime=lastDateTime&downloadSuccess=downloadSuccess'

fetch(path).then(function(response) {
    console.log(response)
    // {ErrorCode: "403", ErrorDescription: 'Not allowed', Success: false }
})
```
