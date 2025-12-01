import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class TabsRow extends StatefulWidget {
  const TabsRow({super.key});

  @override
  State<TabsRow> createState() => _TabsRowState();
}

class _TabsRowState extends State<TabsRow> {

 late final List<String> tabs = [
   "${context.translate(LangKeys.all)} ${context.translate(LangKeys.allLeavesValue)}",
   "${context.translate(LangKeys.approved)} (${context.translate(LangKeys.approvedValue)})",
   "${context.translate(LangKeys.pending)} (${context.translate(LangKeys.pendingValue)})",
 ];

  int selectedIndex = 1;

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 8.w, vertical: 4.h),
      decoration: BoxDecoration(
        border: Border.all(color: const Color(0xFFF4F4F4)),
        borderRadius: BorderRadius.circular(100.sp),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: List.generate(
          tabs.length,
              (index) => GestureDetector(
            onTap: () {
              setState(() {
                selectedIndex = index;
              });
            },
            child: _tabItem(tabs[index], index == selectedIndex),
          ),
        ),
      ),
    );
  }

 Widget _tabItem(String title, bool selected) {
   return Container(
     height: selected ? 41.h : null,
     padding: EdgeInsets.symmetric(vertical: 10.h, horizontal: 18.w),
     decoration: BoxDecoration(
       borderRadius: BorderRadius.circular(20.sp),
       gradient: selected
           ? const LinearGradient(
         colors: [Color(0xFF1BABB6), Color(0xCC005157)],
       )
           : null,
       color: selected ? null : Colors.transparent,
     ),
     alignment: Alignment.center,
     child: FittedBox(
       fit: BoxFit.scaleDown,
       child: Text(
         title,
         style: TextStyle(
           fontSize: 12.sp,
           fontWeight: selected ? FontWeight.w700 : FontWeight.w600,
           color: selected ? Colors.white : Colors.black,
         ),
       ),
     ),
   );
 }

}
