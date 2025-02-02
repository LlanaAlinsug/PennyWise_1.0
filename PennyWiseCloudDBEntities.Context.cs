﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PennyWise
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PennyWiseCloudDBEntities : DbContext
    {
        public PennyWiseCloudDBEntities()
            : base("name=PennyWiseCloudDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<expenseTable> expenseTables { get; set; }
        public virtual DbSet<incomeTable> incomeTables { get; set; }
        public virtual DbSet<loginTable> loginTables { get; set; }
        public virtual DbSet<messageTable> messageTables { get; set; }
        public virtual DbSet<plannerTable> plannerTables { get; set; }
        public virtual DbSet<userTable> userTables { get; set; }
    
        public virtual ObjectResult<Nullable<int>> GetMostRecentPlannerID(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetMostRecentPlannerID", userIDParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspAddExpense(Nullable<int> userID, Nullable<int> expenseID, string description, Nullable<decimal> amount, string category, string subcategory, Nullable<System.DateTime> date)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var expenseIDParameter = expenseID.HasValue ?
                new ObjectParameter("expenseID", expenseID) :
                new ObjectParameter("expenseID", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(decimal));
    
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            var subcategoryParameter = subcategory != null ?
                new ObjectParameter("subcategory", subcategory) :
                new ObjectParameter("subcategory", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspAddExpense", userIDParameter, expenseIDParameter, descriptionParameter, amountParameter, categoryParameter, subcategoryParameter, dateParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspAddIncome(Nullable<int> incomeID, Nullable<int> userID, string incomeSource, Nullable<decimal> incomeAmount, Nullable<System.DateTime> incomeDate, string incomeDesc)
        {
            var incomeIDParameter = incomeID.HasValue ?
                new ObjectParameter("incomeID", incomeID) :
                new ObjectParameter("incomeID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var incomeSourceParameter = incomeSource != null ?
                new ObjectParameter("incomeSource", incomeSource) :
                new ObjectParameter("incomeSource", typeof(string));
    
            var incomeAmountParameter = incomeAmount.HasValue ?
                new ObjectParameter("incomeAmount", incomeAmount) :
                new ObjectParameter("incomeAmount", typeof(decimal));
    
            var incomeDateParameter = incomeDate.HasValue ?
                new ObjectParameter("incomeDate", incomeDate) :
                new ObjectParameter("incomeDate", typeof(System.DateTime));
    
            var incomeDescParameter = incomeDesc != null ?
                new ObjectParameter("incomeDesc", incomeDesc) :
                new ObjectParameter("incomeDesc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspAddIncome", incomeIDParameter, userIDParameter, incomeSourceParameter, incomeAmountParameter, incomeDateParameter, incomeDescParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspApplyOrModifyBudgetPlan(Nullable<int> plannerid, Nullable<int> userid, Nullable<System.DateTime> startdate, Nullable<System.DateTime> enddate, Nullable<decimal> allowance, Nullable<decimal> savingsgoal, Nullable<decimal> needsamount, Nullable<decimal> wantsamount, Nullable<decimal> fundsamount, Nullable<double> needspercent, Nullable<double> wantspercent, Nullable<double> fundspercent)
        {
            var planneridParameter = plannerid.HasValue ?
                new ObjectParameter("plannerid", plannerid) :
                new ObjectParameter("plannerid", typeof(int));
    
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var startdateParameter = startdate.HasValue ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(System.DateTime));
    
            var enddateParameter = enddate.HasValue ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(System.DateTime));
    
            var allowanceParameter = allowance.HasValue ?
                new ObjectParameter("allowance", allowance) :
                new ObjectParameter("allowance", typeof(decimal));
    
            var savingsgoalParameter = savingsgoal.HasValue ?
                new ObjectParameter("savingsgoal", savingsgoal) :
                new ObjectParameter("savingsgoal", typeof(decimal));
    
            var needsamountParameter = needsamount.HasValue ?
                new ObjectParameter("needsamount", needsamount) :
                new ObjectParameter("needsamount", typeof(decimal));
    
            var wantsamountParameter = wantsamount.HasValue ?
                new ObjectParameter("wantsamount", wantsamount) :
                new ObjectParameter("wantsamount", typeof(decimal));
    
            var fundsamountParameter = fundsamount.HasValue ?
                new ObjectParameter("fundsamount", fundsamount) :
                new ObjectParameter("fundsamount", typeof(decimal));
    
            var needspercentParameter = needspercent.HasValue ?
                new ObjectParameter("needspercent", needspercent) :
                new ObjectParameter("needspercent", typeof(double));
    
            var wantspercentParameter = wantspercent.HasValue ?
                new ObjectParameter("wantspercent", wantspercent) :
                new ObjectParameter("wantspercent", typeof(double));
    
            var fundspercentParameter = fundspercent.HasValue ?
                new ObjectParameter("fundspercent", fundspercent) :
                new ObjectParameter("fundspercent", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspApplyOrModifyBudgetPlan", planneridParameter, useridParameter, startdateParameter, enddateParameter, allowanceParameter, savingsgoalParameter, needsamountParameter, wantsamountParameter, fundsamountParameter, needspercentParameter, wantspercentParameter, fundspercentParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> uspCalculateExpenseIncomeRatioCounts(Nullable<int> plannerID)
        {
            var plannerIDParameter = plannerID.HasValue ?
                new ObjectParameter("PlannerID", plannerID) :
                new ObjectParameter("PlannerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("uspCalculateExpenseIncomeRatioCounts", plannerIDParameter);
        }
    
        public virtual int uspCreateNewAccount(string username, string password, ObjectParameter returnvalue)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspCreateNewAccount", usernameParameter, passwordParameter, returnvalue);
        }
    
        public virtual int uspDeleteExpense(Nullable<int> userid, Nullable<int> expenseid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var expenseidParameter = expenseid.HasValue ?
                new ObjectParameter("expenseid", expenseid) :
                new ObjectParameter("expenseid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspDeleteExpense", useridParameter, expenseidParameter);
        }
    
        public virtual int uspDeleteIncome(Nullable<int> userID, Nullable<int> incomeID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var incomeIDParameter = incomeID.HasValue ?
                new ObjectParameter("incomeID", incomeID) :
                new ObjectParameter("incomeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspDeleteIncome", userIDParameter, incomeIDParameter);
        }
    
        public virtual ObjectResult<uspFilterExpensesByCategory_Result> uspFilterExpensesByCategory(Nullable<int> userid, string category)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspFilterExpensesByCategory_Result>("uspFilterExpensesByCategory", useridParameter, categoryParameter);
        }
    
        public virtual ObjectResult<uspFilterExpensesByDate_Result> uspFilterExpensesByDate(Nullable<int> userid, Nullable<System.DateTime> startdate, Nullable<System.DateTime> enddate)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var startdateParameter = startdate.HasValue ?
                new ObjectParameter("startdate", startdate) :
                new ObjectParameter("startdate", typeof(System.DateTime));
    
            var enddateParameter = enddate.HasValue ?
                new ObjectParameter("enddate", enddate) :
                new ObjectParameter("enddate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspFilterExpensesByDate_Result>("uspFilterExpensesByDate", useridParameter, startdateParameter, enddateParameter);
        }
    
        public virtual ObjectResult<uspFilterExpensesBySubcategory_Result> uspFilterExpensesBySubcategory(Nullable<int> userid, string subcategory)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var subcategoryParameter = subcategory != null ?
                new ObjectParameter("subcategory", subcategory) :
                new ObjectParameter("subcategory", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspFilterExpensesBySubcategory_Result>("uspFilterExpensesBySubcategory", useridParameter, subcategoryParameter);
        }
    
        public virtual ObjectResult<uspFilterIncomeByDate_Result> uspFilterIncomeByDate(Nullable<int> userID, Nullable<System.DateTime> startDateIncome, Nullable<System.DateTime> endDateIncome)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateIncomeParameter = startDateIncome.HasValue ?
                new ObjectParameter("startDateIncome", startDateIncome) :
                new ObjectParameter("startDateIncome", typeof(System.DateTime));
    
            var endDateIncomeParameter = endDateIncome.HasValue ?
                new ObjectParameter("endDateIncome", endDateIncome) :
                new ObjectParameter("endDateIncome", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspFilterIncomeByDate_Result>("uspFilterIncomeByDate", userIDParameter, startDateIncomeParameter, endDateIncomeParameter);
        }
    
        public virtual ObjectResult<uspFilterIncomeBySource_Result> uspFilterIncomeBySource(Nullable<int> userID, string searchIncomeSource)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var searchIncomeSourceParameter = searchIncomeSource != null ?
                new ObjectParameter("searchIncomeSource", searchIncomeSource) :
                new ObjectParameter("searchIncomeSource", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspFilterIncomeBySource_Result>("uspFilterIncomeBySource", userIDParameter, searchIncomeSourceParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspGetActualExpenses_FundsAmount(Nullable<int> userID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspGetActualExpenses_FundsAmount", userIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspGetActualExpenses_NeedsAmount(Nullable<int> userID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspGetActualExpenses_NeedsAmount", userIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspGetActualExpenses_WantsAmount(Nullable<int> userID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspGetActualExpenses_WantsAmount", userIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<uspGetActualExpensesPercentage_Result> uspGetActualExpensesPercentage(Nullable<int> userID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetActualExpensesPercentage_Result>("uspGetActualExpensesPercentage", userIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspGetCurrentBalance(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspGetCurrentBalance", userIDParameter);
        }
    
        public virtual ObjectResult<uspGetExpenses_Result> uspGetExpenses(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetExpenses_Result>("uspGetExpenses", useridParameter);
        }
    
        public virtual ObjectResult<uspGetIncome_Result> uspGetIncome(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetIncome_Result>("uspGetIncome", userIDParameter);
        }
    
        public virtual ObjectResult<string> uspGetPersonalizedMessage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspGetPersonalizedMessage");
        }
    
        public virtual ObjectResult<string> uspGetPersonalizedMessageByPositivityScore(Nullable<int> positivityScore)
        {
            var positivityScoreParameter = positivityScore.HasValue ?
                new ObjectParameter("PositivityScore", positivityScore) :
                new ObjectParameter("PositivityScore", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("uspGetPersonalizedMessageByPositivityScore", positivityScoreParameter);
        }
    
        public virtual ObjectResult<uspGetPlannedExpenses_Result> uspGetPlannedExpenses(Nullable<int> userID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetPlannedExpenses_Result>("uspGetPlannedExpenses", userIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspGetSavingsGoal(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspGetSavingsGoal", userIDParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspGetTotalExpenses(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspGetTotalExpenses", userIDParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspGetTotalIncome(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspGetTotalIncome", userIDParameter);
        }
    
        public virtual int uspLogIn(string username, string password, ObjectParameter returnvalue, ObjectParameter userID, ObjectParameter loginID)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspLogIn", usernameParameter, passwordParameter, returnvalue, userID, loginID);
        }
    
        public virtual int uspLogOut(Nullable<int> userid, Nullable<int> loginid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var loginidParameter = loginid.HasValue ?
                new ObjectParameter("loginid", loginid) :
                new ObjectParameter("loginid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspLogOut", useridParameter, loginidParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspPlannedAndActualDiff(Nullable<int> userID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspPlannedAndActualDiff", userIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<uspRetrieveAccountDetails_Result> uspRetrieveAccountDetails(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspRetrieveAccountDetails_Result>("uspRetrieveAccountDetails", userIDParameter);
        }
    
        public virtual ObjectResult<uspSearchExpensesByDesc_Result> uspSearchExpensesByDesc(Nullable<int> userid, string search)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspSearchExpensesByDesc_Result>("uspSearchExpensesByDesc", useridParameter, searchParameter);
        }
    
        public virtual ObjectResult<uspSearchIncomeByDesc_Result> uspSearchIncomeByDesc(Nullable<int> userid, string search)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspSearchIncomeByDesc_Result>("uspSearchIncomeByDesc", useridParameter, searchParameter);
        }
    
        public virtual int uspUpdateExpense(Nullable<int> userID, Nullable<int> expenseID, string description, Nullable<decimal> amount, string category, string subcategory, Nullable<System.DateTime> date)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var expenseIDParameter = expenseID.HasValue ?
                new ObjectParameter("expenseID", expenseID) :
                new ObjectParameter("expenseID", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(decimal));
    
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            var subcategoryParameter = subcategory != null ?
                new ObjectParameter("subcategory", subcategory) :
                new ObjectParameter("subcategory", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateExpense", userIDParameter, expenseIDParameter, descriptionParameter, amountParameter, categoryParameter, subcategoryParameter, dateParameter);
        }
    
        public virtual int uspUpdateIncome(Nullable<int> incomeID, Nullable<int> userID, string incomeSource, Nullable<decimal> incomeAmount, Nullable<System.DateTime> incomeDate, string incomeDesc)
        {
            var incomeIDParameter = incomeID.HasValue ?
                new ObjectParameter("incomeID", incomeID) :
                new ObjectParameter("incomeID", typeof(int));
    
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var incomeSourceParameter = incomeSource != null ?
                new ObjectParameter("incomeSource", incomeSource) :
                new ObjectParameter("incomeSource", typeof(string));
    
            var incomeAmountParameter = incomeAmount.HasValue ?
                new ObjectParameter("incomeAmount", incomeAmount) :
                new ObjectParameter("incomeAmount", typeof(decimal));
    
            var incomeDateParameter = incomeDate.HasValue ?
                new ObjectParameter("incomeDate", incomeDate) :
                new ObjectParameter("incomeDate", typeof(System.DateTime));
    
            var incomeDescParameter = incomeDesc != null ?
                new ObjectParameter("incomeDesc", incomeDesc) :
                new ObjectParameter("incomeDesc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateIncome", incomeIDParameter, userIDParameter, incomeSourceParameter, incomeAmountParameter, incomeDateParameter, incomeDescParameter);
        }
    }
}
