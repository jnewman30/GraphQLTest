/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO DataAdapterTypes ( [Name] ) VALUES ( 'GraphQL' )

DECLARE @UserJson varchar(max) = '[
  {
    "id": "5bcb9f09a21aff276f66c3a1",
    "firstName": "Frederick",
    "lastName": "Simon",
    "company": "Corporana",
    "userName": "frederick.simon@corporana.net",
    "email": "frederick.simon@corporana.net"
  },
  {
    "id": "5bcb9f09b98acb0b9f1ba9b2",
    "firstName": "Anastasia",
    "lastName": "Coffey",
    "company": "Zilphur",
    "userName": "anastasia.coffey@zilphur.name",
    "email": "anastasia.coffey@zilphur.name"
  },
  {
    "id": "5bcb9f09e7f9de7731689a00",
    "firstName": "Tiffany",
    "lastName": "Moreno",
    "company": "Centrexin",
    "userName": "tiffany.moreno@centrexin.biz",
    "email": "tiffany.moreno@centrexin.biz"
  },
  {
    "id": "5bcb9f09559046f06ee61920",
    "firstName": "Pamela",
    "lastName": "Gibbs",
    "company": "Ohmnet",
    "userName": "pamela.gibbs@ohmnet.info",
    "email": "pamela.gibbs@ohmnet.info"
  },
  {
    "id": "5bcb9f092539b2c2f7a50c4c",
    "firstName": "Lindsey",
    "lastName": "Holland",
    "company": "Liquidoc",
    "userName": "lindsey.holland@liquidoc.co.uk",
    "email": "lindsey.holland@liquidoc.co.uk"
  },
  {
    "id": "5bcb9f09084e7abff654d1e9",
    "firstName": "Wilson",
    "lastName": "Lindsey",
    "company": "Bittor",
    "userName": "wilson.lindsey@bittor.com",
    "email": "wilson.lindsey@bittor.com"
  },
  {
    "id": "5bcb9f096bdb40a6cc012e1c",
    "firstName": "Shana",
    "lastName": "Huffman",
    "company": "Exiand",
    "userName": "shana.huffman@exiand.us",
    "email": "shana.huffman@exiand.us"
  },
  {
    "id": "5bcb9f09bd4ba4daed9b3ac8",
    "firstName": "Guerra",
    "lastName": "Houston",
    "company": "Fitcore",
    "userName": "guerra.houston@fitcore.me",
    "email": "guerra.houston@fitcore.me"
  },
  {
    "id": "5bcb9f09d3bfc6b0a0de4298",
    "firstName": "Teresa",
    "lastName": "Potts",
    "company": "Aquafire",
    "userName": "teresa.potts@aquafire.org",
    "email": "teresa.potts@aquafire.org"
  },
  {
    "id": "5bcb9f09cb458cf80bf124cc",
    "firstName": "Brandi",
    "lastName": "Kane",
    "company": "Dognosis",
    "userName": "brandi.kane@dognosis.biz",
    "email": "brandi.kane@dognosis.biz"
  },
  {
    "id": "5bcb9f09bb65b8415b2e307d",
    "firstName": "Anderson",
    "lastName": "Aguilar",
    "company": "Namebox",
    "userName": "anderson.aguilar@namebox.ca",
    "email": "anderson.aguilar@namebox.ca"
  },
  {
    "id": "5bcb9f092c27a7900d1a862f",
    "firstName": "Maddox",
    "lastName": "York",
    "company": "Acrodance",
    "userName": "maddox.york@acrodance.tv",
    "email": "maddox.york@acrodance.tv"
  },
  {
    "id": "5bcb9f09c50a1a2ac72f35ad",
    "firstName": "Norton",
    "lastName": "Pruitt",
    "company": "Enormo",
    "userName": "norton.pruitt@enormo.net",
    "email": "norton.pruitt@enormo.net"
  },
  {
    "id": "5bcb9f096871a86c389c5da5",
    "firstName": "Violet",
    "lastName": "Saunders",
    "company": "Cipromox",
    "userName": "violet.saunders@cipromox.name",
    "email": "violet.saunders@cipromox.name"
  },
  {
    "id": "5bcb9f09f7e26450ab1442f3",
    "firstName": "Jennifer",
    "lastName": "Mccarthy",
    "company": "Velos",
    "userName": "jennifer.mccarthy@velos.biz",
    "email": "jennifer.mccarthy@velos.biz"
  },
  {
    "id": "5bcb9f09f7cf79fc55e1551b",
    "firstName": "Mayra",
    "lastName": "Wallace",
    "company": "Viagreat",
    "userName": "mayra.wallace@viagreat.info",
    "email": "mayra.wallace@viagreat.info"
  },
  {
    "id": "5bcb9f09ebb2694649516799",
    "firstName": "Katelyn",
    "lastName": "Albert",
    "company": "Paragonia",
    "userName": "katelyn.albert@paragonia.co.uk",
    "email": "katelyn.albert@paragonia.co.uk"
  },
  {
    "id": "5bcb9f092cba27dd1a8da009",
    "firstName": "Twila",
    "lastName": "Carpenter",
    "company": "Pathways",
    "userName": "twila.carpenter@pathways.com",
    "email": "twila.carpenter@pathways.com"
  },
  {
    "id": "5bcb9f09d094a79ea8d378d0",
    "firstName": "Joyner",
    "lastName": "Chaney",
    "company": "Dancity",
    "userName": "joyner.chaney@dancity.us",
    "email": "joyner.chaney@dancity.us"
  },
  {
    "id": "5bcb9f096ea2611791a897de",
    "firstName": "Ryan",
    "lastName": "Shannon",
    "company": "Nurali",
    "userName": "ryan.shannon@nurali.me",
    "email": "ryan.shannon@nurali.me"
  }
]'

INSERT INTO Users ( Id, UserName, Email, FirstName, LastName, Company )
SELECT Id, UserName, Email, FirstName, LastName, Company
FROM OPENJSON(@UserJson)
 WITH (
	id nvarchar(128), 
	userName nvarchar(25), 
	email nvarchar(255), 
	firstName nvarchar(50), 
	lastName nvarchar(50),
	company nvarchar(255),
	dateCreated datetimeoffset(7)
)