import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/leaves/widgets/design_request_leave_row.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class RequestsTypes extends StatefulWidget {
   const RequestsTypes({super.key});

   @override
   State<RequestsTypes> createState() => _RequestsTypesState();
 }

 class _RequestsTypesState extends State<RequestsTypes> {
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         RequestLeaveRow(
             rightImage: Assets.imagesLeaveRequest,
             leftImage: Assets.imagesArrowIcon,
             text: context.translate(LangKeys.leaveRequest),
             onPressed: (){
               Navigator.pushNamed(context,AppRoutes.leaveRequestView);
             } ,
         ),
         SizedBox(height: 20.h,),
         RequestLeaveRow(
             rightImage: Assets.imagesMission,
             leftImage: Assets.imagesArrowIcon,
             text: context.translate(LangKeys.businessTripRequest)),
         SizedBox(height: 20.h,),
         RequestLeaveRow(
             rightImage: Assets.imagesPermissionRequest,
             leftImage: Assets.imagesArrowIcon,
             text: context.translate(LangKeys.permissionRequest)),
         SizedBox(height: 20.h,),
         RequestLeaveRow(
             rightImage: Assets.imagesLetterRequest,
             leftImage: Assets.imagesArrowIcon,
             text: context.translate(LangKeys.letterRequest)),
         SizedBox(height: 20.h,),
         RequestLeaveRow(
             rightImage: Assets.imagesSpecialRequest,
             leftImage: Assets.imagesArrowIcon,
             text: context.translate(LangKeys.specialRequest)),
       ],
     );
   }
 }
