Feature: Buying a product on LA Store

    @BuyFirstTvInList
    Scenario: Buy a first appeared TV in the search list
        Given I am on the LAStore homepage
        And I go to catalog
        And I choose TV section
        Given I choose the first one from the search list
        And I click "Add to cart" button from the first vendor in the list
        When I Click "Proceed to order"
        Then The Order page is loaded