import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/leaves/widgets/build_app_bar_row.dart';
import 'package:athr_hr/features/leaves/widgets/build_leaves_types_row.dart';
import 'package:athr_hr/features/leaves/widgets/build_state_leaves_column.dart';
import 'package:athr_hr/features/leaves/widgets/leaves_card.dart';
import 'package:athr_hr/features/leaves/widgets/tabs_row.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class LeavesWidget extends StatefulWidget {


  const LeavesWidget({super.key,});

  @override
  State<LeavesWidget> createState() => _LeavesWidgetState();
}

class _LeavesWidgetState extends State<LeavesWidget> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Padding(
          padding: EdgeInsets.all(8.sp),
          child: Column(
            children: [
              SizedBox(height: 20.h),
              BuildRow(
                titleKey: context.translate(LangKeys.leaves),
                image: Assets.imagesLeavebutton,
                onPressed: (){
                  Navigator.pushNamed(context, AppRoutes.leaveRequestView);
                },
              ),
              SizedBox(height: 20.h),
              StateLeavesColumn(),
              SizedBox(height: 24.h),
              BuildLeavesTypesRow(),
              SizedBox(height: 16.h),
              TabsRow(),
              SizedBox(height: 16.h),
              Expanded(
                child: SingleChildScrollView(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    LeaveCard(
                      status: context.translate(LangKeys.approvedStatus),
                      leaveType: context.translate(LangKeys.familyLeave),
                      duration: context.translate(LangKeys.oneDay),
                      fromDate: context.translate(LangKeys.date20251110),
                      toDate: context.translate(LangKeys.date20251115),
                    ),
                    SizedBox(height: 12),
                    LeaveCard(
                      status: context.translate(LangKeys.pendingStatus),
                      leaveType: context.translate(LangKeys.familyLeave),
                      duration: context.translate(LangKeys.oneDay),
                      fromDate: context.translate(LangKeys.date20251110),
                      toDate: context.translate(LangKeys.date20251115),
                    ),
                    SizedBox(height: 12),
                    LeaveCard(
                      status: context.translate(LangKeys.approvedStatus),
                      leaveType: context.translate(LangKeys.familyLeave),
                      duration: context.translate(LangKeys.oneDay),
                      fromDate: context.translate(LangKeys.date20251110),
                      toDate: context.translate(LangKeys.date20251115),
                    ),
                  ],
                ),
              ),
            ),
              SizedBox(height: 20.h),
            ],
          ),
        ),
      ),
    );
  }
}
