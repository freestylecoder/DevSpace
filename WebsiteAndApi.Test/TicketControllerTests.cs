﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DevSpace.Api.Controllers;
using DevSpace.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevSpace.WebsiteAndApi.Test {
	[TestClass]
	public class TicketControllerTests {
		internal class testDataStore : IDataStore<IStudentCode> {
			public Task<IStudentCode> Get( int Id ) {
				throw new NotImplementedException();
			}

			public Task<IList<IStudentCode>> Get( string Field, object Value ) {
				return Task.FromResult( new List<IStudentCode>() as IList<IStudentCode> );
			}

			public Task<IList<IStudentCode>> GetAll() {
				throw new NotImplementedException();
			}
		}

		[TestMethod]
		public void TestMethod1() {
			TicketController TestObject = new TicketController( new testDataStore() );
			try {
				HttpResponseMessage response = TestObject.Post( "cjg0001@uah.edu" ).Result;
			} catch( AggregateException Ex ) {
				WebException InnerEx = Ex.InnerException as WebException;
				using( StreamReader Reader = new StreamReader( InnerEx.Response.GetResponseStream() ) ) {
					string response = Reader.ReadToEnd();
						Assert.Fail( response );
				}
			}
		}
	}
}