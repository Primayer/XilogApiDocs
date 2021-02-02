# Primayer Xilog API documentation

Questions? Find us at [development@ovarro.com](mailto:development@primayer.co.uk)

# Xilog Data Access

The Primayer API provides access to the raw data recorded by the Xilog logger. To use the API third parties must provide an authorization token with each request. The authorization token can be found within the settings section of [PrimeWeb](https://cloud.primayer.com). 

# Methods

- [*getsites*](#getsitestoken): Returns all sites for the access token
- [*getchannels*](#getchannelssiteid-token): Returns all channels for site
- [*getdata*](#getdatasiteid-channelid-token-startdate-enddate-timewindowstart-timewindowend): Returns data for logger channel specified by date time range.
- [*getdatatounits*](#getdatatounitssiteid-channelid-token-startdate-enddate-units): Returns data converted to units, for logger channel specified by date time range.)
- [*getheader*](#getheadersiteid-channelid-token): Returns header data for logger channel.
- [*getnewdata*](#getnewdatasiteid-channelid-token): Returns last batch of channel data sent from logger.
- [*confirmdownload*](#confirmdownloadsiteid-channelid-token-lastdatetime-downloadsuccess): Returns the status code of last transaction sent from logger.
- [*getmeter*](#getmetersiteid-channelid-token-startdate-enddate-timewindowstart-timewindowend): Returns meter data for logger channel specified by date time range.
- [*getnewmeter*](#getnewmetersiteid-channelid-token): Returns last batch of channel meter data sent from logger.
- [*getminmax*](#getminmaxsiteid-channelid-token-startdate-enddate): Returns the min/max values for a logger channel specified by date time range.

# API

#### For more in depth C# and JavaScript examples of the API, see the examples folder.

## getsites(token)

##### Purpose
Returns array of site ids for the access token

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getsites
  2. Params
   - token: (string - required)
      - access token
     
##### Return Value
  An array of integers:

##### Example

```javascript
const path = 'https://decode.primayer.com/api/xilog/getsites?token=token'

fetch(path).then(function(response) {
    console.log(response)
    // [0, 1, 2, 3, 4, 5, 6, 7]
})
```

<br />

## getchannels(siteID, token)

##### Purpose
Get all channel indexes associated with the logger

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getchannels
  2. Params
   - siteId: (string - required)
      - logger serial number
   - token: (string - required)
      - access token    
     
##### Return Value
  An array of strings:

##### Example

```javascript
const path = 'https://decode.primayer.com/api/xilog/getchannels?siteID=serial&token=token'

fetch(path).then(function(response) {
    console.log(response)
    // ["D1a", "D2a", "A1", "A2",]
})
```

<br />

## getdata(siteID, channelID, token, startDate, endDate, timeWindowStart, timeWindowEnd)

##### Purpose
Returns a collection of the raw channel data for the specified Xilog logger. (Max 8 days)

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getdata
  2. Params
   - siteID: (string - required)
      - logger site id as displayed on device.
   - channelID: (string - required)
      - specifies which channel's data should be returned.  
   - token: (string - required)
      - api authorization token.
   - startDate: (string - MM/dd/yyyy)
      - Date at which to start querying loggers channel data.
   - endDate: (string -  MM/dd/yyyy)
      - Date at which to finish querying loggers channel data.
   - timeWindowStart: (string)
      - Time at which to start querying loggers channel data. (can be empty)
   - timeWindowEnd: (string)
      - Time at which to finish querying loggers channel data. (can be empty)
      

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
const path = 'https://decode.primayer.com/api/xilog/getdata?siteID=serial_number&channelID=channel_index&token=token&startDate=s_date&endDate=e_date&timeWindowStart=s_time&timeWindowEnd=f_time'

fetch(path).then(function(response) {
    console.log(response)
    // [{Timestamp: "01/10/2015 09:00:00", Value: 11000.0000}, {Timestamp: "01/10/2015 09:10:00", Value: 11089.0000}, {Timestamp: "01/10/2015 09:20:00", Value: 11780.0000}...]
})
```

<br />

## getdatatounits(siteID, channelID, token, startDate, endDate, units)

##### Purpose
Returns a collection of the channel data for the specified Xilog logger converted to a specified unit. (Max 7 days)

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getdatatounits
  2. Params
   - siteID: (string - required)
      - logger site id as displayed on device.
   - channelID: (string - required)
      - specifies which channel's data should be returned.  
   - token: (string - required)
      - api authorization token.
   - startDate: (string - MM/dd/yyyy)
      - Date at which to start querying loggers channel data.
   - endDate: (string -  MM/dd/yyyy)
      - Date at which to finish querying loggers channel data.
   - units: (string)
      - enumeration value of the unit (check examples for unit enumerations)
      

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
const path = 'https://decode.primayer.com/api/xilog/getdatatounits?siteID=serial_number&channelID=channel_index&token=token&startDate=s_date&endDate=e_date&units=u'

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
    - https://decode.primayer.com/api/xilog/getheader
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
   Interval: number,
   SiteName : string
}
```

##### Example

```javascript
const path = 'https://decode.primayer.com/api/xilog/getheader?siteID=serial_number&channelID=channel_index&token=token'

fetch(path).then(function(response) {
    console.log(response)
    // {Type: '', ReadingsType: '', Units: '', Interval: '', SiteName: ''}
})
```

<br />

## getnewdata(siteID, channelID, token)

##### Purpose
Returns the last batch of data sent from the logger for the specified channel.

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getnewdata
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
const path = 'https://decode.primayer.com/api/xilog/getnewdata?siteID=serial_number&channelID=channel_index&token=token'

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
    - https://decode.primayer.com/api/xilog/confirmdownload
  2. Params
   - siteID: (string - required)
      - logger site id as displayed on device.
   - channelID: (string - required)
      - specifies loggers channel.  
   - token: (string - required)
      - api authorization token.
   - lastDateTime: (string -  MM/dd/yyyy)
      - date of last confirmed download
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
const path = 'https://decode.primayer.com/api/xilog/confirmdownload?siteID=serial_number&channelID=channel_index&token=token&lastDateTime=lastDateTime&downloadSuccess=downloadSuccess'

fetch(path).then(function(response) {
    console.log(response)
    // {ErrorCode: "403", ErrorDescription: 'Not allowed', Success: false }
})
```
<br />

## getmeter(siteID, channelID, token, startDate, endDate, timeWindowStart, timeWindowEnd)

##### Purpose
Returns a collection of the raw channel meter data for the specified Xilog logger. (Max 8 days)

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getmeter
  2. Params
   - siteID: (string - required)
      - logger site id as displayed on device.
   - channelID: (string - required)
      - specifies which channel's data should be returned.  
   - token: (string - required)
      - api authorization token.
   - startDate: (string -  MM/dd/yyyy)
      - Date at which to start querying loggers channel data.
   - endDate: (string -  MM/dd/yyyy)
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
const path = 'https://decode.primayer.com/api/xilog/getmeter?siteID=serial_number&channelID=channel_index&token=token&startDate=s_date&endDate=e_date&timeWindowStart=s_time&timeWindowEnd=f_time'

fetch(path).then(function(response) {
    console.log(response)
    // [{Timestamp: "01/10/2015 00:00:00", Value: 1100000.0000}, {Timestamp: "02/10/2015 00:00:00", Value: 1200000.0000}...]
})
```
<br />

## getnewmeter(siteID, channelID, token)

##### Purpose
Returns the last batch of meter data sent from the logger for the specified channel.

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getnewmeter
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
const path = 'https://decode.primayer.com/api/xilog/getnewmeter?siteID=serial_number&channelID=channel_index&token=token'

fetch(path).then(function(response) {
    console.log(response)
    // [{Timestamp: "01/10/2015 00:00:00", Value: 1100000.0000}, {Timestamp: "02/10/2015 00:00:00", Value: 1200000.0000}...]
})
```
<br />

## getminmax(siteID, channelID, token, startDate, endDate)

##### Purpose
Returns an object which contains the min/max values for a specified Xilog logger/channel. (Max 8 days)

##### Signature
  1. Endpoint
    - https://decode.primayer.com/api/xilog/getminmax
  2. Params
   - siteID: (string - required)
      - logger site id as displayed on device.
   - channelID: (string - required)
      - specifies which channel's data should be returned.  
   - token: (string - required)
      - api authorization token.
   - startDate: (string - MM/dd/yyyy)
      - Date at which to start querying loggers channel data.
   - endDate: (string -  MM/dd/yyyy)
      - Date at which to finish querying loggers channel data.
      

##### Return Value
  An object which contains min/max data:

```javascript
[{
  Serial: integer,
  Channel: string,
  StartRange: string,
  EndRange: string,
  Min: number,
  Max: number,
  Error: string
}]
```


##### Example

```javascript
const path = 'https://decode.primayer.com/api/xilog/getminmax?siteID=serial_number&channelID=channel_index&token=token&startDate=s_date&endDate=e_date'

fetch(path).then(function(response) {
    console.log(response)
    // {Serial: 998815, Channel: 'D1a', StartRange: '2019-01-01T00:00:00', EndRange: '2019-01-02T00:00:00', Min: 0,  Max: 1.99595,  Error: '-'}
})
```
