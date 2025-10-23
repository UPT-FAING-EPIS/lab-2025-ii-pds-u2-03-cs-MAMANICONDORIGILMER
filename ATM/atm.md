```mermaid
classDiagram

class Account
Account : +Int AccountNumber
Account : +Decimal AccountBalance
Account : +Withdraw() Void
Account : +Deposit() Void

class ATM
ATM : +Action() Void

class DepositCommand
DepositCommand : +Execute() Void

class ICommand
ICommand : +Execute() Void

class WithdrawCommand
WithdrawCommand : +Execute() Void


ICommand <|.. DepositCommand
ICommand <|.. WithdrawCommand

```
