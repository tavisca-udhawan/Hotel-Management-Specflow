Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario Outline: User adds hotel in database by providing inputs and can get data that was added
       Given User provided valid Id '<id>'  and '<name>'for hotel 
	   And User has added required details for hotel
	   And User calls AddHotel api
	   When User calls Hotel Api By ID '<id>'
	   Then Verify that Hotel by Id <id> exists or not
Examples: 
| id | name           |
| 4  | Cosmo          |
| 5  | Hyatt Regency  |
| 6  | Cosmo Luxury   |

Scenario Outline: User adds multiple hotels in database by providing inputs and can get details of hotels that were added
       Given User provided valid Id '<id1>'  and '<name1>'for hotel 
	   And User has added required details for hotel
	   And User calls AddHotel api
	   And User provided valid Id '<id2>'  and '<name2>'for hotel 
	   And User has added required details for hotel
	   And User calls AddHotel api
	   And User provided valid Id '<id3>'  and '<name3>'for hotel 
	   And User has added required details for hotel
	   And User calls AddHotel api
	   When User calls the Hotel Api
	   Then Verify that the Hotels by Ids '<id1>' exists or not
	    Then Verify that the Hotels by Ids '<id2>' exists or not 
		Then Verify that the Hotels by Ids '<id3>' exists or not
Examples: 
| id1 | id2 | id3 | name1     | name2      | name3          |
| 7   | 8   | 9   | Taj Hotel | JW Marriot | Grand INN      |
| 10  | 11  | 12  | Sunbeam   | Walk INN   | NoVotel Hotels |
