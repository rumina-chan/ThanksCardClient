﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

namespace ThanksCardClient.Services
{
    class RestService : IRestService
    {
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            this.Client = new HttpClient();
            this.BaseUrl = "http://localhost:5000";
        }
        public async Task<User> LogonAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Logon", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseUser;
        }

        public async Task<List<User>> GetDepartmentUsersAsync(long? DepartmentChildrenId)
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/DepartmentUsers/" + DepartmentChildrenId);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUsers = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }

        public async Task<List<User>> GetDepartmentChildrenUsersAsync(long? DepartmentChildrenId)
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/DepartmentUsers/" + DepartmentChildrenId);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUsers = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Users");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUsers = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }

        public async Task<User> PostUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Users", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> PutUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Users/" + user.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> DeleteUserAsync(long Id)
        {
            User responseUser = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Users/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            List<Department> responseDepartments = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Departments");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartments = JsonConvert.DeserializeObject<List<Department>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetDepartmentsAsync: " + e);
            }
            return responseDepartments;
        }

        public async Task<Department> PostDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Departments", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> PutDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Departments/" + department.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> DeleteDepartmentAsync(long Id)
        {
            Department responseDepartment = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Departments/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            List<ThanksCard> responseThanksCards = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/ThanksCard");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCards = JsonConvert.DeserializeObject<List<ThanksCard>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetThanksCardsAsync: " + e);
            }
            return responseThanksCards;
        }

        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            var jObject = JsonConvert.SerializeObject(thanksCard);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/ThanksCard", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCard = JsonConvert.DeserializeObject<ThanksCard>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }

        public async Task<ThanksCard> PutThanksCardAsync(ThanksCard thanksCard)
        {
            var jObject = JsonConvert.SerializeObject(thanksCard);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/ThanksCards/" + thanksCard.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCard = JsonConvert.DeserializeObject<ThanksCard>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }


        public async Task<List<Tag>> GetTagsAsync()
        {
            List<Tag> responseTags = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Tags");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseTags = JsonConvert.DeserializeObject<List<Tag>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetTagsAsync: " + e);
            }
            return responseTags;
        }

        public async Task<Tag> PostTagAsync(Tag tag)
        {
            var jObject = JsonConvert.SerializeObject(tag);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Tag responseTag = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Tags", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseTag = JsonConvert.DeserializeObject<Tag>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostTagAsync: " + e);
            }
            return responseTag;
        }

        public async Task<Tag> PutTagAsync(Tag tag)
        {
            var jObject = JsonConvert.SerializeObject(tag);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Tag responseTag = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Tags/" + tag.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseTag = JsonConvert.DeserializeObject<Tag>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutTagAsync: " + e);
            }
            return responseTag;
        }

        public async Task<Tag> DeleteTagAsync(long Id)
        {
            Tag responseTag = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Tags/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseTag = JsonConvert.DeserializeObject<Tag>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteTagAsync: " + e);
            }
            return responseTag;
        }
        public async Task<List<DepartmentChildren>> GetDepartmentChildrensAsync()
        {
            List<DepartmentChildren> responseDepartmentChildrens = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/DepartmentChildrens");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartmentChildrens = JsonConvert.DeserializeObject<List<DepartmentChildren>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in Restservice.GetDepartmentsAsync:" + e);
            }
            return responseDepartmentChildrens;
        }

        public async Task<DepartmentChildren> PostDepartmentChildrenAsync(DepartmentChildren departmentChildren)
        {
            var jObject = JsonConvert.SerializeObject(departmentChildren);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            DepartmentChildren responseDepartmentChildren = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/DepartmentChildrens", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartmentChildren  = JsonConvert.DeserializeObject<DepartmentChildren>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostTagAsync: " + e);
            }
            return responseDepartmentChildren;
        }

        public async Task<DepartmentChildren> PutDepartmentChildrenAsync(DepartmentChildren departmentChildren)
        {
            var jObject = JsonConvert.SerializeObject(departmentChildren);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            DepartmentChildren responseDepartmentChildren = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/DepartmentChildrens/" + departmentChildren.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartmentChildren = JsonConvert.DeserializeObject<DepartmentChildren>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutTagAsync: " + e);
            }
            return responseDepartmentChildren;
        }

        public async Task<DepartmentChildren> DeleteDepartmentChildrenAsync(long Id)
        {
            DepartmentChildren responseDepartmentChildren = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/DepartmentChildrens/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartmentChildren = JsonConvert.DeserializeObject<DepartmentChildren>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteTagAsync: " + e);
            }
            return responseDepartmentChildren;
        }

        public Task<List<DepartmentChildren>> GetDepartmentChildrensAsync(long? departmentChildrenId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentChildren> LogonAsync(DepartmentChildren departmentChildren)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentChildren>> GetDepartmentDepartmentChildrensAsync(long? departmentChildrenId)
        {
            throw new NotImplementedException();
        }

        public async Task<ThanksCard> DeleteThanksCardAsync(long Id)
        {
            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/ThanksCard/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCard = JsonConvert.DeserializeObject<ThanksCard>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }
    }
}
