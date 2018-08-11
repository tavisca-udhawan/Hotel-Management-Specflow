using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();


        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"User has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [Given(@"User calls AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }
        [When(@"User calls Hotel Api By ID '(.*)'")]
        public void WhenUserCallsHotelApiByID(int id)
        {
          hotel= HotelsApiCaller.GetHotelById(id);
        }
        [Then(@"Verify that Hotel by Id (.*) exists or not")]
        public void ThenVerifyThatHotelByIdExistsOrNot(int id)
        {
            hotel.Should().NotBeNull(string.Format("Hotel with ID {0} not found in response", id));
        }
        [When(@"User calls the Hotel Api")]
        public void WhenUserCallsTheHotelApi()
        {
            hotels=HotelsApiCaller.GetHotels();
        }

        [Then(@"Verify that the Hotels by Ids '(.*)' exists or not")]
        public void ThenVerifyThatTheHotelsByIdsExistsOrNot(int id)
        {
            hotel = hotels.Find(data => data.Id == id);
            hotel.Should().NotBeNull(string.Format("Hotel with ID {0} not found that u added in response not found",id));
        }
       


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
